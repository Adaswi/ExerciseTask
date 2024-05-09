using FluentValidation;
using IntegraTestTask;
using IntegraTestTask.Entities;
using IntegraTestTask.PeopleEndpoints;
using IntegraTestTask.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TestDatabaseContext>(options =>
options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TestDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "WebServiceApi";
    config.Title = "WebServiceApi";
    config.Version = "v1";
});
builder.Services.AddScoped<IValidator<Person>, PersonValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "WebServiceApi";
        config.Path = "";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.AddPeopleEndpoints();

app.Run();
