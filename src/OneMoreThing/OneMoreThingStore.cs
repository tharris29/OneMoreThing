using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OneMoreThing
{
    public class OneMoreThingStore : IOneMoreThingStore
    {
        private readonly List<Thing> _things;

        public OneMoreThingStore(IThingLoader loader)
        {
            _things = loader.Load();
        }

        public IEnumerable<Thing> GetOutboundTest(Uri uri)
        {
            return _things.Where(x => x.Inbound == false && MatchUri(x.Uri, uri) && WithinCurrentDate(x));
        }

        public IEnumerable<Thing> GetInboundTest(Uri uri)
        {
            return _things.Where(x => x.Inbound && MatchUri(x.Uri, uri) && WithinCurrentDate(x));
        }

        private static bool WithinCurrentDate(Thing thing)
        {
            var date = DateTime.UtcNow;
            return date >= thing.Start && date <= thing.End;
        }

        private static bool MatchUri(string uriPattern, Uri uri)
        {
            return uriPattern.Equals("all", StringComparison.InvariantCultureIgnoreCase) ||
                   Regex.IsMatch(uri.PathAndQuery, uriPattern, RegexOptions.IgnoreCase);
        }
    }
}