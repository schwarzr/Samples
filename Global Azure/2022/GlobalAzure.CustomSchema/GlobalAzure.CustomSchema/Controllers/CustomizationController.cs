using System.Text.Json;
using GlobalAzure.CustomSchema.Data;
using GlobalAzure.CustomSchema.Data.Metadata;
using GlobalAzure.CustomSchema.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GlobalAzure.CustomSchema.Controllers
{
    [Route("api/[controller]")]
    public class CustomizationController
    {
        private readonly CrmContext _db;
        private readonly IMetadataRepositorySetter _setter;

        public CustomizationController(CrmContext db, IMetadataRepositorySetter setter)
        {
            _db = db;
            _setter = setter;
        }

        [HttpGet()]
        public Task<MetadataModel> GetCustomizationAsync()
        {
            return Task.FromResult(_db.CustomizationModel);
        }


        [HttpPut("{entityName}")]
        public async Task AddPropertyAsync(string entityName,
            [FromQuery] string propertyName,
            [FromQuery] PropertyType propertyType,
            [FromQuery] bool isNullable)
        {
            var dbEntiy = _db.Model.FindEntityType(entityName);

            MetadataModel model = null;

            var customization = await _db.Customizations.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (customization != null)
            {
                var entities = JsonSerializer.Deserialize<IEnumerable<EntityMetadata>>(customization.Metadata);

                model = new MetadataModel(customization.Id, entities);
            }
            else
            {
                model = new MetadataModel(0, new EntityMetadata[] { });
            }

            EntityMetadata entity = model.Entities.FirstOrDefault(p => p.EntityName == entityName);
            if (entity == null)
            {
                entity = new EntityMetadata(entityName, new PropertyMetadata[] { });
                model.Entities.Add(entity);
            }

            var prop = new PropertyMetadata(propertyName, isNullable, propertyType);
            entity.Properties.Add(prop);

            var addColumn = new AddColumnOperation
            {
                Name = propertyName,
                ClrType = CrmContext.GetClrType(prop),
                IsNullable = prop.IsNullable,
                Table = dbEntiy.GetTableName(),
                Schema = dbEntiy.GetSchema(),
            };

            var generator = ((IInfrastructure<IServiceProvider>)_db).Instance.GetRequiredService<IMigrationsSqlGenerator>();

            var scripts = generator.Generate(new[] { addColumn });

            await using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                foreach (var script in scripts)
                {
                    await _db.Database.ExecuteSqlRawAsync(script.CommandText);
                }

                var dbCustomization = new Customization { Created = DateTime.UtcNow, Metadata = JsonSerializer.Serialize(model.Entities) };
                _db.Add(dbCustomization);

                await _db.SaveChangesAsync();

                var newId = dbCustomization.Id;

                var newModel = new MetadataModel(newId, model.Entities);

                await transaction.CommitAsync();

                _setter.SetModel(newModel);
            }
        }
    }
}
