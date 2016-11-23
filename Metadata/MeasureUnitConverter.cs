using System;
using Newtonsoft.Json;

namespace Backend.Metadata
{
    public class MeasureUnitConverter : JsonConverter
    {
        private readonly string _measureUnit;

        public MeasureUnitConverter(string measureUnit)
        {
            _measureUnit = measureUnit;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value} {_measureUnit}");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) => objectType == typeof (string);
    }
}
