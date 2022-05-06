using GlobalAzure.RestContract.Controllers;
using GlobalAzure.RestContract.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(ToDoController).Assembly)
    .AddRestContract();
builder.Services.AddDbContext<ToDoContext>(p => p.UseSqlite(@"Data Source=c:\Temp\todo.sqlite", p => p.MigrationsAssembly("GlobalAzure.RestContract.Sqlite")));
//builder.Services.AddDbContext<ToDoContext>(p => p.UseSqlServer("Data Source=.;Initial Catalog=ToDo;Integrated Security=True;",p => p.MigrationsAssembly("GlobalAzure.RestContract.SqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ToDoContext>();
    ctx.Database.Migrate();
}

app.Run();
