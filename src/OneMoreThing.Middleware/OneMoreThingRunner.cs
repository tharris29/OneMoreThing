using System.IO;
using Microsoft.Owin;

namespace OneMoreThing.Middleware
{
    public class OneMoreThingRunner : OneMoreThingRunnerBase<IOwinContext>
    {
        public OneMoreThingRunner(IOneMoreThingStore thingStore)
            : base(thingStore)
        {
        }

        public override void OneMoreThingBeforeYouStart(IOwinContext context)
        {
            if (!ValidateInbound(context.Request.ContentType)) return;

            context.Response.Body = new OneMoreThingStream(context.Response.Body);
            context.Request.Body = new OneMoreThingStream(context.Request.Body);

            var requestData = RunTest(OneMoreThingStore.GetInboundTest(context.Request.Uri),
                context.Request.Body, context.Response.Headers);

            context.Request.Body = new MemoryStream(requestData);
        }

        public override void OneMoreThingBeforeYouLeave(IOwinContext context)
        {
            if (!ValidateOutbound(context.Response.ContentType)) return;

            var bodyData = RunTest(OneMoreThingStore.GetOutboundTest(context.Request.Uri),
                context.Response.Body, context.Response.Headers);

            RestoreOriginalStreamWithOneMoreThing(context.Response, new MemoryStream(bodyData));
        }

        private static void RestoreOriginalStreamWithOneMoreThing(IOwinResponse response, Stream oneMoreThingRequest)
        {
            var oneMoreThingStream = response.Body as OneMoreThingStream;

            response.ContentLength = oneMoreThingRequest.Length;

            if (oneMoreThingStream == null) return;
            oneMoreThingStream.PlayOneMoreThingStream(oneMoreThingRequest);

            response.Body = oneMoreThingStream.OriginalStream;
        }
    }
}