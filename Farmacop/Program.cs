using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Farmacop
{
    public delegate void MyDelegate();
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormP MyFormP = new FormP();
            MyFormP.ExitPressed += MyFormP_ExitPressed;
            Application.Run(MyFormP);
        }

        private static void MyFormP_ExitPressed()
        {
            Application.Restart();
        }
    }
}
