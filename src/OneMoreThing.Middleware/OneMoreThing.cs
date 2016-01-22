using System.Threading.Tasks;
using Microsoft.Owin;

namespace OneMoreThing.Middleware
{
    public class OneMoreThing : OwinMiddleware
    {
        private readonly IOneMoreThingStore _oneMoreThingStore;

        public OneMoreThing(OwinMiddleware next, IThingLoader loader) : base(next)
        {
            _oneMoreThingStore = new OneMoreThingStore(loader);
        }

        public override async Task Invoke(IOwinContext context)
        {
            var testRunner = new OneMoreThingRunner(_oneMoreThingStore);
            var runOnce = false;
            var padlock = new object();

            testRunner.OneMoreThingBeforeYouStart(context);

            context.Response.OnSendingHeaders(ctx =>
            {
                lock (padlock)
                {
                    if (runOnce) return;
                    runOnce = true;
                }

                testRunner.OneMoreThingBeforeYouLeave(context);

            },context);

            await Next.Invoke(context);
        }
    }
}