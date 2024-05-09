using FluentValidation;
using FluentValidation.Results;
using IntegraTestTask.Converters;
using IntegraTestTask.DTOs;
using IntegraTestTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegraTestTask.PeopleEndpoints
{
    public static class PersonEndpoints
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

            app.MapPost("/people", async (IValidator <Person> validator, PersonDTO personDTO, TestDatabaseContext dbContext) =>
            {
                var person = PersonConverter.Convert(personDTO);

                ValidationResult validationResult = await validator.ValidateAsync(person);
                if(!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
                dbContext.People.Add(person);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/people/{person.Id}", person);
            });
        }
    }
}
