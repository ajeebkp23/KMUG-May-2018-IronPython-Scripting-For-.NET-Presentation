using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronPythonInWinformApplication
{
    public partial class Form1 : Form
    {
        private ScriptSource source;
        private ScriptEngine engine { get; set; }
        private ScriptScope scope { get; set; }

        public int count;

        public Form1()
        {
            InitializeComponent();

            /* bring up an IronPython runtime */
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
            scope.SetVariable("form", this);
            scope.SetVariable(nameof(button1), button1);
            scope.SetVariable(nameof(button2), button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count += 1;
            scope.SetVariable(nameof(count), count);
            /* create a source tree from code */
            //var scriptContent = "form.Close()";
            var scriptContent = @"
button1.Text = 'Hello KMUG!'
button2.Text = str(count)
";

            RunIt(scriptContent);
        }

        private void RunIt(string scriptContent)
        {
            source =
                engine.CreateScriptSourceFromString(scriptContent);

            /* run the script in the IronPython runtime */
            source.Execute(scope);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //count = 14;
            //scope = engine.CreateScope();
            var countFromScript = scope.GetVariable<int>(nameof(count));
            //var countFromScript = scope.GetVariable<Form1>("form");
            //var countFromScript = scope.GetVariable(nameof(count));
            //MessageBox.Show("Obtained Variable Is :" + countFromScript.count);
            MessageBox.Show("Obtained Variable Is :" + countFromScript);
        }
    }
}