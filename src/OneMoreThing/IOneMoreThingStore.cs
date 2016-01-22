using System;
using System.Collections.Generic;

namespace OneMoreThing
{
    public interface IOneMoreThingStore
    {
        IEnumerable<Thing> GetOutboundTest(Uri uri);
        IEnumerable<Thing> GetInboundTest(Uri uri);
    }
}