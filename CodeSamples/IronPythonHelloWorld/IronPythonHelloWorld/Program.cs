using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace IronPythonHelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* bring up an IronPython runtime */
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();

            /* create a source tree from code */
            ScriptSource source =
                engine.CreateScriptSourceFromString("print 'hello from python'");

            /* run the script in the IronPython runtime */
            source.Execute(scope);
            Console.ReadLine();
        }
    }
}