using Newtonsoft.Json;
using TeamVesper.ExportToJson.Contracts;

namespace TeamVesper.ExportToJson
{
    public class JsonSeriliazer : IJsonSeriliazer
    {
        public string Seriliaze(object obj)
        {
            var result = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return result;
        }
    }
}
