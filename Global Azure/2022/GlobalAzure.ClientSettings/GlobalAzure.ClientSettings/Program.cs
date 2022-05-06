var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.Configure<SampleOptions>(builder.Configuration.GetSection("Angular"));

builder.Services.AddClientSettings()
    .WithOptions<SampleOptions>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapClientSettings("settings.js");
app.MapFallbackToFile("index.html");

app.Run();
