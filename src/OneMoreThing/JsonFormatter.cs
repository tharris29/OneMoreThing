using System.IO;

namespace OneMoreThing
{
    public static class JsonFormatter
    {
        public static bool ValidateContentType(string contentType)
        {
            return contentType.Contains("application/json");
        }

        public static string ReadBody(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var json = new StreamReader(stream).ReadToEnd();
            return json;
        }

    }
}