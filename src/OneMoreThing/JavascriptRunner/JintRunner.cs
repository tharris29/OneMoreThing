using Jint;

namespace OneMoreThing.JavascriptRunner
{
    public class JintJavaScriptContext : IJavaScriptContext
    {
        private Engine _runner;

        public JintJavaScriptContext()
        {
            _runner = new Engine();
        }

        public void Dispose()
        {
            _runner = null;
        }

        public void SetParameter(string parameterName, string value)
        {
            _runner.SetValue(parameterName, value);
        }

        public void Run(string script)
        {
            _runner.Execute(script);
        }

        public object GetParameter(string parameterName)
        {
            return _runner.GetValue(parameterName);
        }
    }
}