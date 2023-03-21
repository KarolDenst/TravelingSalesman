using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace TravelingSalesman
{
    internal class Plotter
    {
        [SupportedOSPlatform("windows")]
        private static string? GetPythonPath(string requiredVersion = "", string maxVersion = "")
        {
            string[] possiblePythonLocations = new string[3] {
                @"HKLM\SOFTWARE\Python\PythonCore\",
                @"HKCU\SOFTWARE\Python\PythonCore\",
                @"HKLM\SOFTWARE\Wow6432Node\Python\PythonCore\"
            };

            // Version number, install path
            Dictionary<string, string> pythonLocations = new();

            foreach (string possibleLocation in possiblePythonLocations)
            {
                string rootKeyName = possibleLocation.Substring(0, 4);
                string actualPath = possibleLocation.Substring(5);

                RegistryKey rootKey = rootKeyName switch
                {
                    "HKLM" => Registry.LocalMachine,
                    "HKCU" => Registry.CurrentUser,
                    _ => throw new NotImplementedException("Unknown root key"),
                };

                RegistryKey? subKey;
                try
                {
                    subKey = rootKey.OpenSubKey(actualPath);
                }
                catch
                {
                    subKey = null;
                }

                if (subKey is null) continue;

                foreach (var v in subKey.GetSubKeyNames())
                {
                    RegistryKey? productKey = subKey.OpenSubKey(v);
                    if (productKey is null) continue;

                    try
                    {
                        string? pythonExePath = productKey
                            .OpenSubKey("InstallPath")
                            ?.GetValue("ExecutablePath")
                            ?.ToString();

                        if (!string.IsNullOrEmpty(pythonExePath))
                        {
                            pythonLocations.Add(v, pythonExePath);
                        }
                    }
                    catch
                    {
                        // couldn't access the InstallPath subkey
                    }
                }
            }

            if (pythonLocations.Count > 0)
            {
                Version desiredVersion = new Version(requiredVersion == "" ? "3.7" : requiredVersion),
                    maxPVersion = new Version(maxVersion == "" ? "999.999.999" : maxVersion);

                string highestVersionPath = "";

                foreach (var (version, installPath) in pythonLocations)
                {
                    // TODO if on 64-bit machine, prefer the 64 bit version over 32 and vice versa
                    int index = version.IndexOf("-"); // For x-32 and x-64 in version numbers
                    string formattedVersion = index > 0 ? version.Substring(0, index) : version;

                    Version thisVersion = new Version(formattedVersion);

                    if (thisVersion.CompareTo(desiredVersion) < 0
                        || thisVersion.CompareTo(maxPVersion) > 0)
                        continue;

                    desiredVersion = thisVersion;
                    highestVersionPath = installPath;
                }

                return highestVersionPath;
            }

            return null;
        }

        public static void PlotResults(string resultsDirPath)
        {
            string? pythonPath = ConfigurationManager.AppSettings.Get("python_path");

            if (string.IsNullOrEmpty(pythonPath) && OperatingSystem.IsWindows())
            {
                pythonPath = GetPythonPath();
            }

            if (pythonPath == null)
                throw new Exception("Python not found!");

            string plotScriptPath = @"../../../../Script/plot_results.py";
            ProcessStartInfo start = new()
            {
                FileName = pythonPath!,
                Arguments = string.Format("{0} {1}", plotScriptPath, resultsDirPath),
                UseShellExecute = false
            };
            Process.Start(start);
        }
    }
}
