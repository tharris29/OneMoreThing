using System;
using System.Collections.Generic;
using OneMoreThing.JavascriptRunner;

namespace OneMoreThing
{
    public class Thing
    {
        private readonly IJavaScriptRunner _javascriptRunner;
        public bool Inbound;
        public string Name;
        public string Script;
        public string Uri;
        public DateTime Start;
        public DateTime End;

        public Thing()
        {
            _javascriptRunner = new JintJavaScriptRunner();
        }

        public Thing(IJavaScriptRunner javascriptRunner)
        {
            _javascriptRunner = javascriptRunner;
        }

        private static string ScriptParameters
        {
            get { return @"
                        if(originalBodyString == '')
                        {
                            var originalBody ={};
                            var Body = {};
                        }
                        else
                        {
                              var originalBody= JSON.parse(originalBodyString);
                                                    var Body = JSON.parse(originalBodyString);
                        }
                      
                        
                        "; }
        }

        private static string ScriptedFinalizer
        {
            get { return @"
                        
                        BodyString = JSON.stringify(Body);"; }
        }

        public string Run(string body, IDictionary<string,string[]> headers)
        {
            using (var runner = _javascriptRunner.Create())
            {
                runner.SetParameter("originalBodyString", body);
                runner.SetParameter("BodyString", "");
                runner.SetParameter("TestRunValue", "");

                var script = ScriptParameters + Script + ScriptedFinalizer;
                runner.Run(script);

                var responseObject = runner.GetParameter("BodyString").ToString();
                var testRunValue = runner.GetParameter("TestRunValue").ToString();

                headers.Add(Name, new[] { testRunValue });
                return responseObject;
            }
        }
    }
}