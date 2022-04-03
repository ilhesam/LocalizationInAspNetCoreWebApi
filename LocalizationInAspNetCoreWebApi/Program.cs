using LocalizationInAspNetCoreWebApi;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add localization services
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

// Register shared resource localizer
builder.Services.AddSingleton<IStringLocalizer, StringLocalizer<SharedResource>>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add localization middlewares
var supportedCultures = new[] { "en-US", "ar", "fa-IR" };
var localizationOptions = new RequestLocalizationOptions
{
    ApplyCurrentCultureToResponseHeaders = true
}
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();