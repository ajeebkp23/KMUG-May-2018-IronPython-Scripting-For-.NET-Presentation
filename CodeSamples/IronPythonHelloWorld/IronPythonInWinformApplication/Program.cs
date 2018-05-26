using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronPythonInWinformApplication
{
    internal class Program
    {
        private static void Main()
        {
            var form1 = new Form1();
            var form2 = new Form2();

            //Application.Run(form1);
            Application.Run(form2);
        }
    }
}