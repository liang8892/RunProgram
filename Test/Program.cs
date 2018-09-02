using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RunProgram;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = @"cd /d d:\lvxl";
            string cmdPath = @"C:\Windows\System32\cmd.exe";
            Parameters pa = new Parameters()
            {
                Command = command,
                CMDPath = cmdPath,
                IsVisible = true
            };
            Thread th = new Thread(RunCMD.Run);
            th.Start(pa);

            Console.ReadLine();
        }
    }
}
