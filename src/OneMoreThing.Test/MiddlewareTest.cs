using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Testing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Owin;
using Shouldly;

namespace OneMoreThing.Test
{
    [TestFixture]
    public class MiddlewareTest
    {
        [Test]
        public void OneMoreThingSaidAfter()
        {
            using (var server = TestServer.Create(builder =>
            {
                builder.Use<Middleware.OneMoreThing>(new TestThingLoader());
                builder.Use((env, next) =>
                {
                    env.Response.ContentType = "application/json; charset=utf-8";
                    return next.Invoke();
                });
            }))
            {
                var responseTask =
                    server.CreateRequest("/getexample").AddHeader("Content-Type", "application/json").GetAsync();

                var response = responseTask.Result;

                var responseText = response.Content.ReadAsStringAsync().Result;

                var responseObject = JObject.Parse(responseText);

                responseObject.GetValue("testproperty1").ShouldBe(true);

                response.Headers.GetValues("inbound-test-1").FirstOrDefault().ShouldBe("test run with good result");
                response.Headers.GetValues("outbound-test-1").FirstOrDefault().ShouldBe("test-partially-run");

                IEnumerable<string> outHeader;
                response.Headers.TryGetValues("outbound-test-2", out outHeader);
                outHeader.ShouldBe(null);
            }
        }
    }
}