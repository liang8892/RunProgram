using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunProgram
{
    public class RunCMD
    {
        /// <summary>
        /// 运行cmd.exe
        /// </summary>
        /// <param name="parameter">参数</param>
        public static void Run(object parameter)
        {
            Parameters pa = parameter as Parameters;
            Process process = new Process(); pa.Result = "ok";
            try
            {
                process.StartInfo.FileName = pa.CMDPath;
                //process.StartInfo.Arguments = pa.Command;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.UseShellExecute = !pa.IsVisible;
                process.StartInfo.CreateNoWindow = !pa.IsVisible;
                process.Start();

                process.StandardInput.WriteLine(pa.Command);
                process.StandardInput.AutoFlush = true;

                process.WaitForExit();
                process.Close();
            }
            catch (Exception e)
            {
                pa.Result = "运行失败：\r\n" + e; 
                process.Close();
            }
            //Console.WriteLine("OK!");
        }


    }

    /// <summary>
    /// 参数
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// 命令
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// cmd.exe路径
        /// </summary>
        public string CMDPath { get; set; }

        /// <summary>
        /// 是否显示新窗口
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        public string Result { get; set; }
    }

}
