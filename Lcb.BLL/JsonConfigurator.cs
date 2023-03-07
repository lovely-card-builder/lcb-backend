using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lcb.BLL
{
    public static class JsonConfigurator
    {
        public static JsonSerializerSettings Configure(this JsonSerializerSettings settings)
        {
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Use this to output UNIX seconds
            // options.SerializerSettings.Converters.Insert(0, new UnixDateTimeConverter());
            settings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ";
            settings.Converters.Insert(0, new TimeSpanConverter());
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return settings;
        }
    }
}