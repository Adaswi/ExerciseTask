using IntegraTestTask.DTOs;
using IntegraTestTask.Entities;

namespace IntegraTestTask.Converters
{
    public static class PersonConverter
    {
        public static Person Convert(PersonDTO personDTO)
        {
            var person = new Person();
            person.FirstName = personDTO.FirstName;
            person.LastName = personDTO.LastName;
            person.Birthdate = personDTO.Birthdate;
            person.Address = personDTO.Address;
            return person;
        }
    }
}
