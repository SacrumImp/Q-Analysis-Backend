using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using q_analysis_backend.Models.Controllers.Analysis.Relations;
using q_analysis_math.Relations;


namespace q_analysis_backend.Converters
{
	public class RelationConverter : JsonConverter<IRelationInput>
    {
		public RelationConverter()
		{
		}

        public override IRelationInput Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var document = JsonDocument.ParseValue(ref reader))
            {
                var root = document.RootElement;
                var relationType = root.GetProperty("$type").GetString();
                switch (relationType)
                {
                    case "Binary":
                        return JsonSerializer.Deserialize<BinaryRelationInput>(root, options);
                    case "Weighted":
                        return JsonSerializer.Deserialize<WeightedRelationInput>(root, options);
                    case "FuzzySetsType1":
                        return JsonSerializer.Deserialize<FuzzySetsType1RelationInput>(root, options);
                    default:
                        throw new JsonException($"Unknown relation type: {relationType}");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, IRelationInput value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

