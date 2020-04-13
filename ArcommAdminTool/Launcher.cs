using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ArcommAdminTool.TroopDistribution;
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
            ValidateTrainingDataSet();
            UpdateVersionNumberFromAssembly();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void ValidateTrainingDataSet()
        {
            var validator = new TrainingDataValidator();

            validator.Validate();
        }

        private static void UpdateVersionNumberFromAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = AssemblyName.GetAssemblyName(assembly.Location);

            File.WriteAllText("version.html", assemblyName.Version.ToString());
        }
    }
}