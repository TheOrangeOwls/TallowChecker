using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Greaux
{
    class Program
    {
        static void EnableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
        static void DisableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
        static bool isStarted(string name)
        {
            Process[] allProcess = Process.GetProcesses();
            foreach(Process p in allProcess)
            {
                if (p.ProcessName == name)
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            while (true)
            {              
                if (!isStarted("tallow"))
                {
                    Console.WriteLine("Problem");
                    DisableAdapter("Ethernet0");
                    Console.ReadKey();
                    EnableAdapter("Ethernet0");
                }
                else
                {
                    Console.WriteLine("All is OK");
                }
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
