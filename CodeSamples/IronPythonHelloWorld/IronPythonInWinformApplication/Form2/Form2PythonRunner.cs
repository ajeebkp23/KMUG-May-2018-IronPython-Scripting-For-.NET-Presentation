using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Reflection;
using System.Windows.Forms;

namespace IronPythonInWinformApplication
{
    public class Form2PythonRunner
    {
        public ScriptEngine Engine;
        public ScriptScope Scope;

        public Form2PythonRunner()
        {
            /* bring up an IronPython runtime */
            Engine = Python.CreateEngine();
            Engine.Runtime.LoadAssembly(Assembly.GetAssembly(typeof(MessageBox)));
            Scope = Engine.CreateScope();
            var messageBoxLoadScript = "from System.Windows.Forms import *";
            RunIt(messageBoxLoadScript);
        }

        public void RunIt(string ScriptContent)
        {
            /* create a source tree from code */
            ScriptSource source =
                Engine.CreateScriptSourceFromString(ScriptContent);

            source.Compile();
            /* run the script in the IronPython runtime */
            source.Execute(Scope);
        }

        public void RunFile(string path)
        {
            var source = Engine.CreateScriptSourceFromFile(path);
            source.Compile();
            source.Execute(Scope);
        }
    }
}