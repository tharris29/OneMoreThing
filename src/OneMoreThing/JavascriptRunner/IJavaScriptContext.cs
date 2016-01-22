using System;

namespace OneMoreThing.JavascriptRunner
{
    public interface IJavaScriptContext : IDisposable
    {
        void SetParameter(string parameterName, string value);
        void Run(string script);
        object GetParameter(string parameterName);
    }
}