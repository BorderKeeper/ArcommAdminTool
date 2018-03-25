using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace Launcher
{
    public static class LauncherWindow
    {
        // It's always nice to ask before downloading
        private static readonly bool shouldPromptForUpgrade = true;

        // This is more or less a constant. But you could change this to read from 
        // a reg key that the user can set from an options menu or something. Options are nice. 
        private static readonly bool disableAutomaticChecking = false;

        // The name of the local file where the binaries are saved and read from. 
        private static readonly string assemblyFilePath = "ArcommAdminTool.dll";

        // The name of the class in your binaries that implements ILauncher.
        private static readonly string launcherClassName = "ArcommAdminTool.Launcher";

        // Your version number. A series of numbers separated by periods.
        private static readonly Regex versionNumberRegex = new Regex(@"^[0-9]\.[0-9]\.[0-9]\.[0-9]$");

        private static readonly string latestVersionUrlRegex = @"https://github.com/BorderKeeper/ArcommAdminTool/releases/download/[0-9]\.[0-9]\.[0-9]\.[0-9]/ArcommAdminTool.dll";

        // The URL that returns the version number of the latest release.
        private static readonly string latestVersionUrl = "https://arcomm.co.uk/ArcommAdminTools/version.html";

        // The URL of the actual file for the latest version.
        private static string latestVersionDownload
        {
            get
            {
                var request = (HttpWebRequest) WebRequest.Create("https://api.github.com/repos/BorderKeeper/ArcommAdminTool/releases/latest");

                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";

                var response = (HttpWebResponse) request.GetResponse();

                string content = string.Empty;
                using (var stream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        content = streamReader.ReadToEnd();
                    }
                }

                return Regex.Match(content, latestVersionUrlRegex).Value;
            }
        }

        // The name of the file that will store the latest version. 
        private static readonly string latestVersionInfoFile = "version.html";

        [STAThread]
        public static void Main(string[] args)
        {
            Assembly binaries = GetAssembly();

            if (binaries == null)
            {
                MessageBox.Show(
                    "First-time download of binaries failed.\n\n" +
                    "This could either be because the server is down or your\n" +
                    "internet connection is being silly.",
                    "FAIL");
            }
            else
            {
                ILauncher launcher = binaries.CreateInstance(launcherClassName) as ILauncher;
                launcher.Launch();
            }
        }

        // The reason a file is used instead of checking the assembly's metadata itself
        // is because checking the metadata requires loading the assembly to check the
        // version. Once the assembly is loaded and it turns out an upgrade is available,
        // you cannot unload the assembly to overwrite the binaries. This is unfortunately
        // a general .NET restriction. 
        private static string GetLocalVersionNumber()
        {
            if (File.Exists(latestVersionInfoFile) && File.Exists(assemblyFilePath))
            {
                return File.ReadAllText(latestVersionInfoFile);
            }
            return null;
        }

        private static void SetLocalVersionNumber(string version)
        {
            File.WriteAllText(latestVersionInfoFile, version);
        }

        /// <summary>
        /// Gets the latest version number from the server.
        /// </summary>
        private static string GetLatestVersion()
        {
            Uri latestVersionUri = new Uri(latestVersionUrl);
            WebClient webClient = new WebClient();
            string receivedData = string.Empty;

            try
            {
                receivedData = webClient.DownloadString(latestVersionUrl).Trim();
            }
            catch (WebException)
            {
                // server or connection is having issues
            }

            // Just in case the server returned something other than a valid version number. 
            return versionNumberRegex.IsMatch(receivedData)
                ? receivedData
                : null;
        }

        private static Assembly GetLocalAssembly()
        {
            if (File.Exists(assemblyFilePath))
            {
                try
                {
                    return Assembly.LoadFrom(assemblyFilePath);
                }
                catch (Exception) { }
            }

            return null;
        }

        private static Assembly GetAssembly()
        {
            bool localAssemblyExists = File.Exists(assemblyFilePath);

            if (disableAutomaticChecking && localAssemblyExists)
            {
                return GetLocalAssembly();
            }

            string latestVersion = GetLatestVersion();

            if (latestVersion == null)
            {
                // Something wrong with connection/server.
                // Just go with the local assembly. 
                return GetLocalAssembly();
            }

            string localVersion = GetLocalVersionNumber();

            if (ShallIDownloadTheLatestBinaries(localVersion, latestVersion, shouldPromptForUpgrade))
            {
                bool success = DownloadLatestAssembly();
                if (success)
                {
                    SetLocalVersionNumber(latestVersion);
                }
            }

            return GetLocalAssembly();
        }

        private static bool ShallIDownloadTheLatestBinaries(string localVersion, string latestVersion, bool shouldAskFirst)
        {
            if (localVersion == latestVersion)
            {
                return false;
            }

            if (!shouldAskFirst)
            {
                return true;
            }

            return MessageBoxResult.Yes == MessageBox.Show(
                "There is a newer version available. Would you like to download it?",
                "New version is avilable",
                MessageBoxButton.YesNo);
        }

        private static bool DownloadLatestAssembly()
        {
            WebClient downloader = new WebClient();
            try
            {
                byte[] latestVersionBytes = downloader.DownloadData(latestVersionDownload);

                // use a temporary download location in case something goes wrong, we don't want to 
                // corrupt the program and make it unusable without making the user manually delete files. 
                string temporaryPath = "t_" + assemblyFilePath;
                File.WriteAllBytes(temporaryPath, latestVersionBytes);

                if (File.Exists(assemblyFilePath))
                {
                    File.Delete(assemblyFilePath);
                }

                File.Move(temporaryPath, assemblyFilePath);
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
