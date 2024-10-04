using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CryptoPay.Converters
{
    /// <summary>
    /// Custom JSON converter to serialize an array of strings as a single comma-separated string and deserialize it back to an array.
    /// </summary>
    public class ArrayToStringConverter : JsonConverter<IEnumerable<string>>
    {
        /// <inheritdoc />
        public override IEnumerable<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<List<string>>(ref reader, options) ?? new List<string>();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, IEnumerable<string> value, JsonSerializerOptions options)
        {
            var joinedString = string.Join(",", value);
            writer.WriteStringValue(joinedString);
        }
    }
}