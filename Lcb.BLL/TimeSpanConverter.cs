using Newtonsoft.Json;

namespace Lcb.BLL
{
    /// <summary>
    /// TimeSpans are not serialized consistently depending on what properties are present. So this 
    /// serializer will ensure the format is maintained no matter what.
    /// </summary>
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Format: Days.Hours:Minutes:Seconds:Milliseconds
        /// </summary>
        public const string TimeSpanFormatString = "hh\\:mm";

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            var timespanFormatted = $"{value.ToString(TimeSpanFormatString)}";
            writer.WriteValue(timespanFormatted);
        }

        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            TimeSpan.TryParseExact((string)reader.Value, TimeSpanFormatString, null, out var parsedTimeSpan);
            return parsedTimeSpan;
        }
    }
}