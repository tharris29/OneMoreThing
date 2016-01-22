using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OneMoreThing.Loader
{
    public class ThingFileLoader : IThingLoader
    {
        private readonly string _filePath;

        public ThingFileLoader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Thing> Load()
        {
            string oneMoreThingJson;
            using (var streamReader = new StreamReader(_filePath))
            {
                oneMoreThingJson = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Thing>>(oneMoreThingJson);
        }
    }
}