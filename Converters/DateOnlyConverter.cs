using System.Text.Json;
using System.Text.Json.Serialization;

namespace IntegraTestTask.Converters
{
    public sealed class DateOnlyConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateOnly value = default(DateOnly);
            try
            {
                value = DateOnly.FromDateTime(reader.GetDateTime());
            }
            catch (Exception ex) { }
            return value;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            var isoDate = value.ToString("O");
            writer.WriteStringValue(isoDate);
        }
    }
}
