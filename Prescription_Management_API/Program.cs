using Microsoft.OpenApi.Models;
using Prescription_Management_API.Interface;
using Prescription_Management_API.Repositories;
using Prescription_Management_API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering the repository and service
builder.Services.AddSingleton<Prescription_Management_API.Interface.IPrescriptionRepository, Prescription_Management_API.Repositories.InMemoryPrescriptionRepository>();
builder.Services.AddSingleton<IPatientRepository, InMemoryPatientRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(swaggerGen =>
{
    swaggerGen.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Prescription Management API",
        Version = "v1",
        Description = "API for managing patients and prescriptions",
        Contact = new OpenApiContact
        {
            Name = "VINAY KUMAR P",
            Email = "vinay.kumar@viturahealth.com"
        }
    });

    // Include XML comments (optional)
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //swaggerGen.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI(swaggerUI =>
        {
            swaggerUI.SwaggerEndpoint("/swagger/v1/swagger.json", "Prescription Management API V1");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
