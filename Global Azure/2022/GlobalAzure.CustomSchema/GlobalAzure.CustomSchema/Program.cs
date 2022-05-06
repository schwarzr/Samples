using System.Text.Json;
using GlobalAzure.CustomSchema.Data;
using GlobalAzure.CustomSchema.Data.Metadata;
using GlobalAzure.CustomSchema.Database;
using GlobalAzure.CustomSchema.Database.Extendable;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<DefaultMetadataRepository>();
builder.Services.AddTransient<IMetadataRepository>(p => p.GetRequiredService<DefaultMetadataRepository>());
builder.Services.AddTransient<IMetadataRepositorySetter>(p => p.GetRequiredService<DefaultMetadataRepository>());
builder.Services.AddTransient<MetadataModel>(p => p.GetRequiredService<IMetadataRepository>().GetModel());

builder.Services.AddSingleton<IAdditionalDataEntityMapping, AdditionalDataEntityMapping<CustomerDetailItem, Customer>>();
builder.Services.AddSingleton<IAdditionalDataEntityMapping, AdditionalDataEntityMapping<CustomerListData, Customer>>();
builder.Services.AddSingleton<IAdditionalDataEntityMapping, AdditionalDataEntityMapping<CustomerPayloadItem, Customer>>();

builder.Services.AddDbContext<CrmContext>(p => p.UseSqlServer("Data Source=.; Initial Catalog=CrmCustomization;Integrated Security=true;"));
builder.Services.AddOpenApiDocument<CrmContext
    >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<CrmContext>();
    await ctx.Database.EnsureCreatedAsync();

    var customization = await ctx.Customizations.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
    if (customization != null)
    {
        var entities = JsonSerializer.Deserialize<IEnumerable<EntityMetadata>>(customization.Metadata);

        var model = new MetadataModel(customization.Id, entities);
        scope.ServiceProvider.GetRequiredService<IMetadataRepositorySetter>().SetModel(model);
    }
}

app.Run();
