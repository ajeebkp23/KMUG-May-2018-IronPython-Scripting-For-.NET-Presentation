using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronPythonInWinformApplication
{
    public partial class Form2 : Form
    {
        //public static Logger logger = LogManager.GetCurrentClassLogger();
        public static Logger logger = LogManager.GetLogger("Form2Logger");

        public Form2PythonRunner Runner { get; set; }

        public Form2()
        {
            InitializeComponent();
            Runner = new Form2PythonRunner();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Runner.Engine.Runtime.LoadAssembly(Assembly.GetAssembly(typeof(Form2)));
            Runner.Engine.Runtime.LoadAssembly(Assembly.GetAssembly(typeof(LogManager)));
            var loadAssembly = $@"
from IronPythonInWinformApplication import *
#from NLog import *
";
            Runner.RunIt(loadAssembly);
            var scriptContent = $@"
form2 = Form2()
#logger = LogManager.GetLogger('Form2Logger')
#logger.Info('Hello, logger world')
form2.ShowDialog()
";
            Runner.RunIt(scriptContent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var scriptContent = @"
def hi(kmug):
    MessageBox.Show('Say, Hi to {}'.format(kmug))
";
            Runner.RunIt(scriptContent);
            dynamic methodHi = Runner.Scope.GetVariable("hi");
            methodHi("Awesome people at KMUG");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var scriptContent = @"
class BaseClass1:
    def run(self,buddy):
        MessageBox.Show('You run with: {}'.format(buddy))

class BaseClass2:
    def dance(self,buddy):
        MessageBox.Show('You dance with: {}'.format(buddy))

class BaseClass3:
    def eat(self,food):
        MessageBox.Show('You eat dish: {}'.format(food))

class SubclassName(BaseClass1, BaseClass2, BaseClass3):
    pass
";
            Runner.RunIt(scriptContent);
            dynamic SubclassName = Runner.Scope.GetVariable("SubclassName");
            dynamic subclassInstance = SubclassName();
            subclassInstance.eat("Mango");
            subclassInstance.dance("John Skeet");
            subclassInstance.run("Ussain Bolt");
        }
    }
}