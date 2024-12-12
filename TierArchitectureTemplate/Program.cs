using BusinessLayer.Logic.Configuration;
using DataAccessLayer.Configuration;
using TierArchitectureTemplate.API.Middleware.Exception;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// DotNetEnv
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

// Add Serilog support
builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));
builder.Logging.AddSerilog();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.RegisterBusinessLogicDI();
builder.Services.RegisterDataAccessDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();    

app.Run();
