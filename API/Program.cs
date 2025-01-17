using Serilog;
using Domain.Logic.Configuration;
using DataAccess.Logic.Configuration;
using API.Attributes.Controllers;
using API.Middleware.Exception;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// DotNetEnv
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

// Add Serilog support
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));
builder.Logging.AddSerilog();

// Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "DTO/MessagesResources");

// Controllers
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ValidateModelAttribute>();
}).AddDataAnnotationsLocalization();

// Supported cultures
var supportedCultures = new[] { "en", "pl" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
localizationOptions.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1",
        new()
        {
            Title = builder.Configuration["ApiSpecification:Name"],
            Version = "v1"
        });
});

// Add services to the container.
builder.Services.RegisterBusinessLogicServices();
builder.Services.RegisterDataAccessServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRequestLocalization(localizationOptions);

app.MapControllers();

// Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();    

app.Run();
