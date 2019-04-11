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
        static void EnableAdapter(string interfaceName) // Добавляем в программу функцию отключения интерфейса
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
        static void DisableAdapter(string interfaceName) // Добавляем в программу функцию отключения интерфейса
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
        }
        static bool isStarted(string name) // проверка запущен ли процесс
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
            while (true) // запуск бесконечного цикла
            {              
                if (!isStarted("tallow")) // проверка на то отсутствует ли процесс, если его нету то..
                {
                    Console.WriteLine("Problem, pause your VM or close browser"); // Вывод того что процесс отсутствует
                    DisableAdapter("Ethernet0"); //Вместо Ethernet0 - название вашего адаптера
                    Console.ReadKey(); // Ожидание нажатия клавиши
                    Console.WriteLine("Start Tallow then press any key to start network status checker again");
                    EnableAdapter("Ethernet0"); //Вместо Ethernet0 - название вашего адаптера
                    Console.ReadKey(); // Запуск цикла по новой
                    Console.WriteLine("Started"); // предупреждение что цикл запущен с 0
                }
                else // Если он есть, то
                {
                    Console.WriteLine("All is OK"); // Пишет что всё нормально
                }
                System.Threading.Thread.Sleep(1000); // задержка перед каждым кругом (не обязательно, но сделано чтобы не перегружать компьютер)
            }
        }
    }
}
