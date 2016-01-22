namespace OneMoreThing.JavascriptRunner
{
    public class JintJavaScriptRunner : IJavaScriptRunner
    {
        public IJavaScriptContext Create()
        {
            return new JintJavaScriptContext();
        }
    }
}