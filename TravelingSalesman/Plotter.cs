﻿using Microsoft.Win32;
using System.Diagnostics;

namespace TravelingSalesman
{
    internal class Plotter
    {
        private static string GetPythonPath(string requiredVersion = "", string maxVersion = "")
        {
            string[] possiblePythonLocations = new string[3] {
                @"HKLM\SOFTWARE\Python\PythonCore\",
                @"HKCU\SOFTWARE\Python\PythonCore\",
                @"HKLM\SOFTWARE\Wow6432Node\Python\PythonCore\"
            };

            //Version number, install path
            Dictionary<string, string> pythonLocations = new Dictionary<string, string>();

            foreach (string possibleLocation in possiblePythonLocations)
            {
                string regKey = possibleLocation.Substring(0, 4), actualPath = possibleLocation.Substring(5);
                RegistryKey theKey = (regKey == "HKLM" ? Registry.LocalMachine : Registry.CurrentUser);
                RegistryKey theValue = theKey.OpenSubKey(actualPath);
                if (theValue is null) continue;

                foreach (var v in theValue.GetSubKeyNames())
                {
                    RegistryKey productKey = theValue.OpenSubKey(v);
                    if (productKey != null)
                    {
                        try
                        {
                            string pythonExePath = productKey.OpenSubKey("InstallPath").GetValue("ExecutablePath").ToString();

                            // Comment this in to get (Default) value instead
                            // string pythonExePath = productKey.OpenSubKey("InstallPath").GetValue("").ToString();

                            if (pythonExePath != null && pythonExePath != "")
                            {
                                //Console.WriteLine("Got python version; " + v + " at path; " + pythonExePath);
                                pythonLocations.Add(v.ToString(), pythonExePath);
                            }
                        }
                        catch
                        {
                            //Install path doesn't exist
                        }
                    }
                }
            }

            if (pythonLocations.Count > 0)
            {
                System.Version desiredVersion = new System.Version(requiredVersion == "" ? "0.0.1" : requiredVersion),
                    maxPVersion = new System.Version(maxVersion == "" ? "999.999.999" : maxVersion);

                string highestVersion = "", highestVersionPath = "";

                foreach (KeyValuePair<string, string> pVersion in pythonLocations)
                {
                    //TODO; if on 64-bit machine, prefer the 64 bit version over 32 and vice versa
                    int index = pVersion.Key.IndexOf("-"); //For x-32 and x-64 in version numbers
                    string formattedVersion = index > 0 ? pVersion.Key.Substring(0, index) : pVersion.Key;

                    System.Version thisVersion = new System.Version(formattedVersion);
                    int comparison = desiredVersion.CompareTo(thisVersion),
                        maxComparison = maxPVersion.CompareTo(thisVersion);

                    if (comparison <= 0)
                    {
                        //Version is greater or equal
                        if (maxComparison >= 0)
                        {
                            desiredVersion = thisVersion;

                            highestVersion = pVersion.Key;
                            highestVersionPath = pVersion.Value;
                        }
                        else
                        {
                            //Console.WriteLine("Version is too high; " + maxComparison.ToString());
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Version (" + pVersion.Key + ") is not within the spectrum.");
                    }
                }

                //Console.WriteLine(highestVersion);
                //Console.WriteLine(highestVersionPath);
                return highestVersionPath;
            }

            return "";
        }

        private static string GetPath()
        {
            var entries = Environment.GetEnvironmentVariable("path").Split(';');
            string python_location = null;

            foreach (string entry in entries)
            {
                if (entry.ToLower().Contains("python"))
                {
                    var breadcrumbs = entry.Split('\\');
                    foreach (string breadcrumb in breadcrumbs)
                    {
                        if (breadcrumb.ToLower().Contains("python"))
                        {
                            python_location += breadcrumb + '\\';
                            break;
                        }
                        python_location += breadcrumb + '\\';
                    }
                    break;
                }
            }

            return python_location;
        }

        public static void PlotResults(string resultsPath, string title)
        {
            string pythonPath = GetPythonPath();
            string plotScriptPath = @"../../../../Script/plot_results.py";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonPath;
            start.Arguments = string.Format("{0} {1} {2}", plotScriptPath, resultsPath, title);
            start.UseShellExecute = false;
            Process.Start(start);
        }
    }
}
