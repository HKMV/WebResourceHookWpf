using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace WebResourceHookWpf.Lib
{
    public class Core
    {
        #region 数据绑定

        /// <summary>
        /// <see cref="DownloadResourceInfo" /> 这是属性的名称.
        /// </summary>
        public const string DownloadResourceInfoPropertyName = "DownloadResourceInfo";

        private static string _downloadResourceInfo;

        /// <summary>
        /// Sets 和 gets DownloadResourceInfo 的属性。
        /// 对该属性值的更改将引发PropertyChanged事件。
        /// </summary>
        public static string DownloadResourceInfo
        {
            get
            {
                return _downloadResourceInfo;
            }

            set
            {
                if (_downloadResourceInfo == value)
                {
                    return;
                }

                _downloadResourceInfo = value;
                //RaisePropertyChanged(DownloadResourceInfoPropertyName);
            }
        }

        #endregion 数据绑定

        /// <summary>
        /// 修正目录（检测修正目录后面是否有“/”||"\"）
        /// </summary>
        /// <param name="path">原目录</param>
        /// <returns>修正后的目录</returns>
        public static string CorrectionPath(string path)
        {
            string s = path.Substring(path.Length - 1);

            if (path.Contains("/") && !"/".Equals(s))
            {
                path += "/";
            }
            else if (path.Contains("\\") && !"\\".Equals(s))
            {
                path += "\\";
            }
            /*
            if (s != "/" && s != "\\")
            {
                path += "/";
            }*/

            return path;
        }

        /// <summary>
        /// 获取指定目录下的所有文件(相对路径)
        /// </summary>
        /// <param name="path">资源路径</param>
        /// <param name="rootPath">根路径</param>
        /// <returns>所有文件的相对路径</returns>
        public static List<string> GetAllFile(string path,string rootPath)
        {
            //StreamWriter sw = new StreamWriter(new FileStream("fileList.txt", FileMode.Append));
            DirectoryInfo directory = new DirectoryInfo(path);
            List<string> files = new List<string>();
            rootPath = CorrectionPath(rootPath);

            FileInfo[] fileInfos = directory.GetFiles();
            foreach (FileInfo fi in fileInfos)
            {
                files.Add(fi.FullName.Replace(rootPath,""));
            }

            DirectoryInfo[] directoryInfos= directory.GetDirectories();
            foreach (DirectoryInfo di in directoryInfos)
            {
                files.AddRange(GetAllFile(di.FullName, rootPath));
            }
            

            return files;
        }

        /// <summary>
        /// 写出到文件
        /// </summary>
        /// <param name="path">存放的目录</param>
        /// <param name="info">写出的信息</param>
        public static void WriteErrorlogToFile(string path, string info)
        {
            try
            {
                File.AppendAllText("error.log", "[E]" + "  " + DateTime.Now + " --> " + info + "\n");
            }
            catch (Exception e)
            {
                Debug.WriteLine("写入日志出错:" + e.Message + "\n" + e.StackTrace);
            }
        }


        #region Aria2c

        /// <summary>
        /// 使用Aria2c进行文件下载
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <param name="saveFilePath">保存路径(不含文件名)</param>
        /// <returns></returns>
        public static bool DownloadFileByAria2Async(string url, string saveFilePath)
        {
            if (!Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }

            var tool = Environment.CurrentDirectory + "\\Down\\aria2c.exe";
            string[] strings = url.Split('/');
            string FileName = strings[strings.Length - 1];
            saveFilePath = saveFilePath + "\\" + FileName;
            var fi = new FileInfo(saveFilePath);
            var command = " -c -s 10 -x 10  --file-allocation=none --check-certificate=false -d " + fi.DirectoryName + " -o " + fi.Name + " " + url;
            using (var p = new Process())
            {
                RedirectExcuteProcess(p, tool, command, (s, e) => ShowInfo(url, e.Data));
            }
            return File.Exists(saveFilePath) && new FileInfo(saveFilePath).Length > 0;
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="url"></param>
        /// <param name="a"></param>
        private static void ShowInfo(string url, string a)
        {
            if (a == null)
            {
                return;
            }

            //用于匹配下载进度
            const string re1 = ".*?"; // Non-greedy match on filler
            const string re2 = "(\\(.*\\))"; // Round Braces 1

            var r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var m = r.Match(a);
            if (m.Success)
            {
                var rbraces1 = m.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
                if (rbraces1 == "OK")
                {
                    rbraces1 = "100";
                }

                string info = DateTime.Now.ToString().Replace("/", "-") + "    " + url + "    下载进度:" + rbraces1 + "%";

                DownloadResourceInfo = info;
                Console.WriteLine(info);
            }
        }

        /// <summary>
        /// 功能：重定向执行
        /// </summary>
        /// <param name="p"></param>
        /// <param name="exe"></param>
        /// <param name="arg"></param>
        /// <param name="output"></param>
        private static void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output)
        {
            p.StartInfo.FileName = exe;
            p.StartInfo.Arguments = arg;

            p.StartInfo.UseShellExecute = false;    //输出信息重定向
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;

            p.OutputDataReceived += output;
            p.ErrorDataReceived += output;

            p.Start();                    //启动线程
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();            //等待进程结束
        }

        #endregion Aria2c
    }
}