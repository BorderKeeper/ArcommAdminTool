using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
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
            UpdateTrainingData();

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

        private static void UpdateTrainingData()
        {
            var latestTrainingDataLink = GetLatestTrainingDataUrl();

            if (latestTrainingDataLink != string.Empty)
            {
                DownloadLatestTrainingData(latestTrainingDataLink);
            }
        }

        private static string GetLatestTrainingDataUrl()
        {
            var versionRegex = @"[0-9]\.[0-9]\.[0-9]\.[0-9]";
            var trainingDataRegex = $"https://github.com/BorderKeeper/ArcommAdminTool/releases/download/{versionRegex}/TrainingData.xml";
            var latestVersionGitHubUrl = @"https://api.github.com/repos/BorderKeeper/ArcommAdminTool/releases/latest";
            var requestMethod = "GET";
            var userAgent = "ArcommAdminTool";

            var request = (HttpWebRequest)WebRequest.Create(latestVersionGitHubUrl);

            request.Method = requestMethod;
            request.UserAgent = userAgent;

            var response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            Match latestReleaseUrl = Regex.Match(content, trainingDataRegex);

            if (latestReleaseUrl.Success)
            {
                return latestReleaseUrl.Value;
            }

            return string.Empty;
        }

        private static bool DownloadLatestTrainingData(string path)
        {
            WebClient downloader = new WebClient();
            try
            {
                byte[] latestVersionBytes = downloader.DownloadData(path);

                // use a temporary download location in case something goes wrong, we don't want to 
                // corrupt the program and make it unusable without making the user manually delete files. 
                string temporaryPath = Path.GetTempFileName();
                File.WriteAllBytes(temporaryPath, latestVersionBytes);

                if (File.Exists("TrainingData.xml"))
                {
                    File.Delete("TrainingData.xml");
                }

                File.Move(temporaryPath, "TrainingData.xml");
            }
            catch (Exception)
            {
                // so much can go wrong
                return false;
            }
            return true;
        }
    }
}