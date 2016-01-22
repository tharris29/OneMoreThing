using System.IO;

namespace OneMoreThing.Middleware
{
    public class OneMoreThingStream : MemoryStream
    {
        public OneMoreThingStream(Stream stream)
        {
            OriginalStream = stream;
        }

        public Stream OriginalStream { get; private set; }

        public void PlayOneMoreThingStream(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(OriginalStream);
        }
    }
}