using Speaker.Control.Interface;
using System.Diagnostics;

namespace Speaker.Control.Services
{
    public class MachineService : IMachineService
    {
        #region Private Properties

        private const string ShutdownCommand = "shutdown";
        private const string HibernateCommandArgs = "/h";
        private const string PowerOffCommandArgs = "/s /t 0";

        #endregion Private Properties

        public void Hibernate()
        {
            ExecShell(ShutdownCommand, HibernateCommandArgs);
        }

        public void Shutdown()
        {
            ExecShell(ShutdownCommand, PowerOffCommandArgs);
        }

        private void ExecShell(string command, string args)
        {
            var processInfo = new ProcessStartInfo(command, args);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            Process.Start(processInfo);
        }
    }
}