using IntegraTestTask.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace IntegraTestTask.PeopleEndpoints
{
    public static class PeopleEndpoints
    {
        public static void AddPeopleEndpoints(this IEndpointRouteBuilder app)
        {

            app.MapGet("/people", async (TestDatabaseContext dbContext) =>
                await dbContext.People.ToListAsync());

            app.MapGet("/people/{id}", async (int id, TestDatabaseContext dbContext) =>
                await dbContext.People.FindAsync(id)
                    is Person person
                        ? Results.Ok(person)
                        : Results.NotFound());

            app.MapPost("/people", async (Person person, TestDatabaseContext dbContext) =>
            {
                dbContext.People.Add(person);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/people/{person.Id}", person);
            });
        }
    }
}
