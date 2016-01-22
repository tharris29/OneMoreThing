using System;
using System.Collections.Generic;

namespace OneMoreThing.Test
{
    public class TestThingLoader : IThingLoader
    {
        public List<Thing> Load()
        {
            return new List<Thing>
            {
                new Thing
                {
                    End = DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    Inbound = false,
                    Name = "outbound-test-1",
                    Start = DateTime.UtcNow.Add(TimeSpan.FromDays(-1)),
                    Script =
                        "  Body.testproperty1 = true;\r\n                    Body.testproperty2 = 'test data';\r\n                    Body.testproperty3 = ['value1','value2','value3'];\r\n\r\n                    TestRunValue = \"test-partially-run\"\r\n\r\nif(Body.Healthy)\r\n                    {\r\n                        Body.Healthy = false;\r\n\t\tTestRunValue = \"test-run\"\r\n                    }\r\n\r\n                  \r\n",
                    Uri = "all"
                },
                new Thing
                {
                    End = DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    Inbound = true,
                    Name = "inbound-test-1",
                    Start = DateTime.UtcNow.Add(TimeSpan.FromDays(-1)),
                    Script =
                        "Body.testproperty3 = ['value1','value2','value3'];\r\nTestRunValue = \"test run with good result\"",
                    Uri = "/getexample"
                },
                new Thing
                {
                    End = DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
                    Inbound = false,
                    Name = "inbound-test-2",
                    Start = DateTime.UtcNow.Add(TimeSpan.FromDays(+1)),
                    Script =
                        "  Body.testproperty1 = true;\r\n                    Body.testproperty2 = 'test data';\r\n                    Body.testproperty3 = ['value1','value2','value3'];\r\n\r\n                    TestRunValue = \"test-partially-run\"\r\n\r\nif(Body.Healthy)\r\n                    {\r\n                        Body.Healthy = false;\r\n\t\tTestRunValue = \"test-run\"\r\n                    }\r\n\r\n                  \r\n",
                    Uri = "/"
                }
            };
        }
    }
}