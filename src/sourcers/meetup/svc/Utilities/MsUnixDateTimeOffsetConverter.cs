using System;
using Newtonsoft.Json;

namespace Tehk.Sourcers.Meetup.Svc.Utilities
{
    /// <summary>
    /// Supports Unix timestamps defined in miliseconds, and are converted into DateTimeOffset.
    /// </summary>
    public class MsUnixDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(DateTimeOffset);

        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value);
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}