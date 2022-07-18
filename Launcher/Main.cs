using System;
using System.Diagnostics;
using System.IO;

namespace Project1
{
    class Class1
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            if (args.Length == 0)
            {
                logger.WriteLog("当前指令为空");
                logger.closeLogger();
                return;
            }
            string appPath = args[0].Replace("mywarehouse://", "");
            logger.WriteLog("已收到指令：" + args[0]);
            string[] strs = appPath.Split('/');
            if (strs == null || strs.Length == 1)
            {
                logger.WriteLog("指令有误");
                logger.closeLogger();
                return;
            }
            string app = strs[strs.Length - 1];
            logger.WriteLog("开始启动：" + app);
            logger.WriteLog("应用路径为："+ appPath);
            Process process = Process.Start(appPath);
            logger.WriteLog("启动成功");
            logger.closeLogger();

            //sw.Flush();                    //清空
            //sw.Close();

            //try
            //{
            //    if (args.Length != 0)
            //    {
            //        string executable = args[2];
            //        /*uncomment the below three lines if the exe file is in the Assets  
            //         folder of the project and not installed with the system*/
            //        /*string path=Assembly.GetExecutingAssembly().CodeBase;
            //        string directory=Path.GetDirectoryName(path);
            //        process.Start(directory+"\\"+executable);*/
            //        Process.Start(executable);
            //    }
            //}
            //catch (Exception)
            //{
            //    //Console.WriteLine(e.Message);
            //    //Console.ReadLine();
            //}
        }
    }

    class Logger
    {
        private StreamWriter log;

        public Logger()
        {
            if (!Directory.Exists("C:/log"))
            {
                Directory.CreateDirectory("C:/log");
            }
            if (!File.Exists("C:/log/LaunchLog.log"))
            {
                log = new StreamWriter(File.Create("C:/log/LaunchLog.log"));
            }else
                log = File.AppendText("C:/log/LaunchLog.log");
        }
        public void WriteLog(string content)
        {
            string date = DateTime.Now.ToString();
            log.WriteLine(date + " Launcher : " + content);
        }
        public void closeLogger()
        {
            WriteLog("退出Launcher");
            log.Flush();
            log.Close();
        }
    }
}
