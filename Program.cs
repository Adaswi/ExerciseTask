using IntegraTestTask;
using IntegraTestTask.PeopleEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TestDatabaseContext>(options =>
options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TestDatabase"))
);

var app = builder.Build();

app.AddPeopleEndpoints();

app.Run();
