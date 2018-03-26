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
        private static readonly bool ShouldPromptForUpgrade = true;

        // This is more or less a constant. But you could change this to read from 
        // a reg key that the user can set from an options menu or something. Options are nice. 
        private static readonly bool DisableAutomaticChecking = false;

        // The name of the local file where the binaries are saved and read from. 
        private static readonly string AssemblyFilePath = "ArcommAdminTool.dll";

        // The name of the class in your binaries that implements ILauncher.
        private static readonly string LauncherClassName = "ArcommAdminTool.Launcher";

        // Version number to extract from the version dll path
        private static readonly string VersionRegex = @"[0-9]\.[0-9]\.[0-9]\.[0-9]";

        // Desired DLL regex we want to extract from the service response
        private static readonly string LatestVersionUrlRegex = $"https://github.com/BorderKeeper/ArcommAdminTool/releases/download/{VersionRegex}/ArcommAdminTool.dll";

        // Service url to get latest version dll and version number
        private static readonly string LatestVersionGithubUrl = @"https://api.github.com/repos/BorderKeeper/ArcommAdminTool/releases/latest";

        // The name of the file that will store the latest version. 
        private static readonly string LatestVersionInfoFile = "version.html";

        private static readonly string RequestMethod = "GET";
        private static readonly string UserAgent = "ArcommAdminTool";

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
                ILauncher launcher = binaries.CreateInstance(LauncherClassName) as ILauncher;
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
            if (File.Exists(LatestVersionInfoFile) && File.Exists(AssemblyFilePath))
            {
                return File.ReadAllText(LatestVersionInfoFile);
            }
            return null;
        }

        private static void SetLocalVersionNumber(string version)
        {
            File.WriteAllText(LatestVersionInfoFile, version);
        }

        private static Assembly GetLocalAssembly()
        {
            if (File.Exists(AssemblyFilePath))
            {
                try
                {
                    return Assembly.LoadFrom(AssemblyFilePath);
                }
                catch (Exception) { }
            }

            return null;
        }

        private static Assembly GetAssembly()
        {
            bool localAssemblyExists = File.Exists(AssemblyFilePath);

            if (DisableAutomaticChecking && localAssemblyExists)
            {
                return GetLocalAssembly();
            }

            Release latestRelease = GetLatestRelease();

            if (latestRelease == null)
            {
                // Something wrong with connection/server.
                // Just go with the local assembly. 
                return GetLocalAssembly();
            }

            string localVersion = GetLocalVersionNumber();

            if (ShallIDownloadTheLatestBinaries(localVersion, latestRelease.Version, ShouldPromptForUpgrade))
            {
                bool success = DownloadLatestAssembly(latestRelease.DllPath);
                if (success)
                {
                    SetLocalVersionNumber(latestRelease.Version);
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

        private static bool DownloadLatestAssembly(string dllPath)
        {
            WebClient downloader = new WebClient();
            try
            {
                byte[] latestVersionBytes = downloader.DownloadData(dllPath);

                // use a temporary download location in case something goes wrong, we don't want to 
                // corrupt the program and make it unusable without making the user manually delete files. 
                string temporaryPath = "t_" + AssemblyFilePath;
                File.WriteAllBytes(temporaryPath, latestVersionBytes);

                if (File.Exists(AssemblyFilePath))
                {
                    File.Delete(AssemblyFilePath);
                }

                File.Move(temporaryPath, AssemblyFilePath);
            }
            catch (Exception)
            {
                // so much can go wrong
                return false;
            }
            return true;
        }

        private static Release GetLatestRelease()
        {
            var request = (HttpWebRequest) WebRequest.Create(LatestVersionGithubUrl);

            request.Method = RequestMethod;
            request.UserAgent = UserAgent;

            var response = (HttpWebResponse) request.GetResponse();

            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    content = streamReader.ReadToEnd();
                }
            }

            Match latestReleaseUrl = Regex.Match(content, LatestVersionUrlRegex);
            Match latestVersion = Regex.Match(latestReleaseUrl.Value, VersionRegex);

            if (latestReleaseUrl.Success && latestVersion.Success)
            {
                return new Release
                {
                    Version = latestVersion.Value,
                    DllPath = latestReleaseUrl.Value
                };
            }

            return null;
        }
    }

    public class Release
    {
        public string Version { get; set; }

        public string DllPath { get; set; }
    }
}
