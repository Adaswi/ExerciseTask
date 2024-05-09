using IntegraTestTask.Converters;
using System.Text.Json.Serialization;

namespace IntegraTestTask.Entities
{
    public class Person
    {
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly Birthdate { get; set; }
        public string Address { get; set; }
    }
}
