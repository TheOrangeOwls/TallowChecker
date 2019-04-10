using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Owls_Network_locker
{
    class Program
    {      
        static void Main(string[] args)
        {
            string networkInterfaceName = "Беспроводная сеть 2";
            while (true)
            {
                Process[] pname = Process.GetProcessesByName("tallow");
                if(pname.Length == 0)
                {
                    Console.WriteLine("Problem");
                    Task TaskOne = Task.Factory.StartNew(() => DisableAdapter(networkInterfaceName) );
                    // - отключение адаптера
                    Console.ReadLine();
                    // - запуск
                    Task TaskTwo = Task.Factory.StartNew(() => EnableAdapter(networkInterfaceName) );
                } 
                else
                {
                    Console.WriteLine("All is OK");
                   Thread.Sleep(1000);
                }
            }
        }
                static void EnableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        static void DisableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}