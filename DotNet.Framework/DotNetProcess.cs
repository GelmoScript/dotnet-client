using DotNet.Framework.Constants;
using System.Diagnostics;
using System.Text;

namespace DotNet.Framework
{
    internal sealed class DotNetProcess
    {
        private readonly Process _process;
        private bool _isRunning = false;

        public DotNetProcess()
        {
            var processStartInfo = new ProcessStartInfo()
            {
                FileName = Command.Dotnet,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                ArgumentList = { }
            };

            _process = new Process()
            {
                StartInfo = processStartInfo
            };

            var standardOut = new StringBuilder();
            var standardErr = new StringBuilder();

            // Process Delegate Output
            _process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                lock (standardOut)
                {
                    if (e.Data != null)
                    {
                        standardOut.AppendLine(e.Data);
                        Console.WriteLine(e.Data);
                    }
                }
            };

            // Process Delegate Error
            _process.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
            {
                lock (standardErr)
                {
                    if (e.Data != null)
                    {
                        standardErr.AppendLine(e.Data);
                    }
                }
            };
        }

        public DotNetProcess AddArgument(string arg)
        {
            _process.StartInfo.ArgumentList.Add(arg);
            return this;
        }

        public void Run()
        {
            if (_process is null || _isRunning) return;
                _isRunning = true;
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();
            _process.WaitForExit();
            _isRunning = false;
        }

        public void Kill()
        {
            if (_process is null || _isRunning) return;
            _process.Kill();
        }
    }
}
