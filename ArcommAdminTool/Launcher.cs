using System;
using System.Windows.Forms;
using Launcher;

namespace ArcommAdminTool
{
    public class Launcher : ILauncher
    {
        public void Launch()
        {
            Main();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}