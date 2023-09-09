using System;
using System.Diagnostics;
using System.IO;

namespace EveryThingAssist_GUI.Class.APP
{
    public class Python_Sync
    {
        private Process process;

        public event Action<string> OutputUpdated;
        public void Process_Start()
        {
            string pythonExe = "./Everything_Assist.exe";

            if (File.Exists("./token.json") && File.Exists("./Everything_Assist.exe"))
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = pythonExe,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };
                process = new Process
                { 
                    StartInfo = processStartInfo, 
                    EnableRaisingEvents = true
                };
                process.OutputDataReceived += Process_OutputDataReceived;

                process.Start();
                
                process.BeginOutputReadLine();
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                OutputUpdated?.Invoke(e.Data);
            }
        }

        public void SendInput(string input)
        {
            if (process?.StandardInput.BaseStream.CanWrite ?? false)
            {
                process.StandardInput.WriteLine(input);
            }
        }

        public string ReadOutput()
        {
            return process.StandardOutput.ReadToEnd();
        }
    }
}