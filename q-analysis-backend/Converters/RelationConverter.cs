using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using q_analysis_math;
using q_analysis_math.Interfaces;


namespace q_analysis_backend.Converters
{
	public class RelationConverter : JsonConverter<IRelation>
    {
		public RelationConverter()
		{
		}

        public override IRelation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var document = JsonDocument.ParseValue(ref reader))
            {
                var root = document.RootElement;
                var relationType = root.GetProperty("$type").GetString();
                switch (relationType)
                {
                    case "Binary":
                        return JsonSerializer.Deserialize<BinaryRelation>(root, options);
                    case "Weighted":
                        return JsonSerializer.Deserialize<WeightedRelation>(root, options);
                    default:
                        throw new JsonException($"Unknown relation type: {relationType}");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, IRelation value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

