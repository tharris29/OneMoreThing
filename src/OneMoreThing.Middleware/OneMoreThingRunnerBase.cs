using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneMoreThing.Middleware
{
    public abstract class OneMoreThingRunnerBase<T>
    {
        protected readonly IOneMoreThingStore OneMoreThingStore;

        protected OneMoreThingRunnerBase(IOneMoreThingStore thingStore)
        {
            OneMoreThingStore = thingStore;
        }

        public abstract void OneMoreThingBeforeYouLeave(T context);
        public abstract void OneMoreThingBeforeYouStart(T context);

        protected bool ValidateInbound(string contentType)
        {
            return contentType != null && JsonFormatter.ValidateContentType(contentType);
        }

        protected bool ValidateOutbound(string contentType)
        {
            return contentType != null && JsonFormatter.ValidateContentType(contentType);
        }

        protected static byte[] RunTest(IEnumerable<Thing> tests, Stream body, IDictionary<string, string[]> headers)
        {
            var jsonBody = JsonFormatter.ReadBody(body);

            jsonBody = tests.Aggregate(jsonBody, (current, test) => test.Run(current, headers));

            var bodyData = Encoding.UTF8.GetBytes(jsonBody);
            return bodyData;
        }
    }
}