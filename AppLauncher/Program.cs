using System;
using System.Diagnostics;
using System.IO;


namespace AppLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.WriteLog("程序启动，指令集合为----------");
            foreach(string str in args)
            {
                logger.WriteLog(str);
            }
            //string[] args = new string[1];
            //args[0] = "mywarehouse://Launch-F:/Game/Game2/Interactive SLG/[2D] [Live2D]hypnoApp_ver1.0.2/HypnoApp.exe";
            string parentPath = typeof(Program).Assembly.Location.Replace("AppLauncher.exe", "");

            //using (StreamReader stream = File.OpenText("./configuration.yaml"))
            //{
            //    YamlStream yamlStreams = new YamlStream();
            //    yamlStreams.Load(stream);
            //    YamlDocument yamlDocument = yamlStreams.Documents[0];
            //    YamlMappingNode rootNode = (YamlMappingNode)yamlDocument.RootNode;
            //    foreach (var entry in rootNode.Children)
            //    {
            //        if (entry.Key.ToString() == "modules")
            //        {
            //            foreach(var modules in (entry.Value as YamlMappingNode).Children)
            //            {

            //            }
            //        }
            //    }
            //}

                


            
            logger.WriteLog("当前工作路径为--> " + logger.GetType().Assembly.Location);

            if (args.Length == 0)
            {
                logger.WriteLog("当前指令为空");
                logger.closeLogger();
                return;
            }
            logger.WriteLog("已收到指令：" + args[0]);

            string source = args[0].Replace("mywarehouse://", "");
            string command = source.Split('-')[0];
            string appPath = source.Split('-')[1];
            

            if (command == "Launch")
            {
                string[] strs = appPath.Split('/');
                if (strs == null || strs.Length == 1)
                {
                    logger.WriteLog("指令有误");
                    logger.closeLogger();
                    return;
                }
                string app = strs[strs.Length - 1];
                logger.WriteLog("开始启动：" + app);
                logger.WriteLog("应用路径为：" + appPath);
                Process process = new Process();

                ProcessStartInfo info = new ProcessStartInfo(appPath);
                info.WorkingDirectory = appPath.Replace(app,"");
                process.StartInfo = info;
                process.Start();
                logger.WriteLog("启动成功");
            }else if (command == "OpenFolder")
            {
                string[] strs = appPath.Split('/');
                if (strs == null || strs.Length == 1)
                {
                    logger.WriteLog("指令有误");
                    logger.closeLogger();
                    return;
                }
                string folderPath = appPath.Replace("/","\\");
                logger.WriteLog("打开文件夹：" + folderPath);

                
                Process.Start("explorer.exe", folderPath);
                logger.WriteLog("打开成功");
            }
            
            logger.closeLogger();

        }
    }

    class Logger
    {
        private StreamWriter log;

        private string parentPath;

        private string logFolderName = "log";

        private string logFileName = "LaunchLog.log";

        public Logger()
        {
            if (!Directory.Exists(/*parentPath+ logFolderName*/"c:/log"))
            {
                Directory.CreateDirectory(/*parentPath + logFolderName*/"c:/log");
            }
            if (!File.Exists(/*parentPath+ logFolderName + "\\" + logFileName*/"c:/log/log.log"))
            {
                log = new StreamWriter(File.Create(/*parentPath + logFolderName + "\\" + logFileName*/"c:/log/log.log"));
            }
            else
                log = File.AppendText(/*parentPath + logFolderName + "\\" + logFileName*/"c:/log/log.log");
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
