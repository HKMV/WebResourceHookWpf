using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using Stylet;
using WebResourceHookWpf.Lib;

namespace WebResourceHookWpf.Pages
{
    public class ShellViewModel : Screen
    {
        #region 资源绑定
        /// <summary>
        /// 资源路径
        /// </summary>
        public const string ResourcesPathPropertyName = "ResourcesPath";
        private string _resourcesPath;
        public string ResourcesPath
        {
            get
            {
                string show = _resourcesPath;
                if (null != show)
                {
                    int s = show.IndexOf("\\");
                    int e = show.LastIndexOf("\\");
                    show = show.Substring(0, s + 1) + "..." + show.Substring(e);
                }

                return show;
            }

            set
            {
                if (_resourcesPath == value)
                {
                    return;
                }

                _resourcesPath = value;
            }
        }


        /// <summary>
        /// <see cref="CommonUrl" /> 这是属性的名称.
        /// </summary>
        public const string CommonUrlPropertyName = "CommonUrl";

        private string _commonUrl = "https://developer.api.autodesk.com/modelderivative/v2/viewers/7.*/";

        /// <summary>
        /// Sets 和 gets CommonUrl 的属性。
        /// 对该属性值的更改将引发PropertyChanged事件。
        /// </summary>
        public string CommonUrl
        {
            get
            {
                return _commonUrl;
            }

            set
            {
                if (_commonUrl == value)
                {
                    return;
                }

                _commonUrl = value;
                //RaisePropertyChanged(CommonUrlPropertyName);
            }
        }

        /// <summary>
        /// <see cref="ResourceName" /> 这是属性的名称.
        /// </summary>
        public const string ResourceNamePropertyName = "ResourceName";

        private string _resourceName;

        /// <summary>
        /// Sets 和 gets ResourceName 的属性。
        /// 对该属性值的更改将引发PropertyChanged事件。
        /// </summary>
        public string ResourceName
        {
            get
            {
                return _resourceName;
            }

            set
            {
                if (_resourceName == value)
                {
                    return;
                }

                _resourceName = value;
                //RaisePropertyChanged(ResourceNamePropertyName);
            }
        }

        public bool _resourceNameIsEnable = true;
        public bool ResourceNameIsEnable
        {
            get
            {
                return _resourceNameIsEnable;
            }
            set
            {
                _resourceNameIsEnable = value;
            }
        }

        /// <summary>
        /// <see cref="DownloadPath" /> 这是属性的名称.
        /// </summary>
        //        public const string DownloadPathPropertyName = "DownloadPath";

        //private string _downloadPath = Environment.CurrentDirectory + "/Data/" + DateTime.Now.Date.ToString("yyyyMMMMdd");//MMMM代表月份显示中文
        private string _downloadPath = Environment.CurrentDirectory + @"\Data\" + DateTime.Now.Date.ToString("yyyyMMdd");

        /// <summary>
        /// Sets 和 gets DownloadPath 的属性。
        /// 对该属性值的更改将引发PropertyChanged事件。
        /// </summary>
        public string DownloadPath
        {
            get
            {
                if (!Directory.Exists(_downloadPath))
                {
                    Directory.CreateDirectory(_downloadPath);
                }
                return _downloadPath;
            }

            /*set
            {
                if (_downloadPath= == value)
                {
                    return;
                }

                _downloadPath= = value;
                //                RaisePropertyChanged(DownloadPathPropertyName);
            }*/
        }

        public List<string> resourceFiles = null;
        public int _resourceCount = 0;
        public int ResourceCount
        {
            get
            {
                return _resourceCount;
            }
            set
            {
                if (value == 0)
                {
                    resourceFiles = null;
                    ResourcesPath = null;
                    ResourceNameIsEnable = true;
                }
                else
                {
                    ResourceNameIsEnable = false;
                }
                _resourceCount = value;
            }
        }

        public string _downloadResourceInfo = null;
        public string DownloadResourceInfo
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
            }
        }

        #region 下载按钮


        public int _downMin;
        public int DownMin
        {
            get
            {
                return _downMin;
            }
            set
            {
                _downMin = value;
            }
        }

        public int _downMax;
        public int DownMax
        {
            get
            {
                return _downMax;
            }
            set
            {
                _downMax = value;
            }
        }

        public int _downValue;
        public int DownValue
        {
            get
            {
                return _downValue;
            }
            set
            {
                _downValue = value;
            }
        }

        public string _downBtnContent="下载";
        public string DownBtnContent
        {
            get
            {
                return _downBtnContent;
            }
            set
            {
                if (_downBtnContent == value)
                {
                    return;
                }
                _downBtnContent = value;
            }
        }


        public bool _downIsEnable = true;
        public bool DownIsEnable
        {
            get
            {
                return _downIsEnable;
            }
            set
            {
                _downIsEnable = value;
            }
        }

        public bool _downIsIndicatorVisible = false;
        public bool DownIsIndicatorVisible
        {
            get
            {
                return _downIsIndicatorVisible;
            }
            set
            {
                _downIsIndicatorVisible = value;
            }
        }
        #endregion 下载按钮

        #endregion 资源绑定


        public void TestDown()
        {
            DownBtnContent = "下载中···";
            DownloadResourceInfo = "正在下载···";
            //DownIsEnable = false;
            //ResourcesPath = "\\测\\试\\数据";

            DownMin = 0;
            DownMax = 100;
            DownIsIndicatorVisible = true;
            Thread.Sleep(1000);
            DownValue = 30;

        }

        /// <summary>
        /// 下载资源（字符ui交互问题）
        /// </summary>
        public void DownloadResource()
        {
            //new Thread(() =>
            //    {

            //    }).Start();

            Task.Run(() =>
            {
                DownIsEnable = false;
                DownIsIndicatorVisible = true;
                DownMin = 0;
                DownBtnContent = "下载中···";

                if (ResourceNameIsEnable)
                {
                    DownMax = 1;
                    DownValue = 0;

                    string url = CommonUrl + ResourceName;
                    MessageBox.Show("完整地址：" + url);
                    bool downloadFileByAria2Async = Core.DownloadFileByAria2Async(url, DownloadPath);
                    MessageBox.Show("下载是否成功：" + downloadFileByAria2Async);
                    DownValue = 1;
                }
                else
                {
                    DownMax = resourceFiles.Count;
                    int i = 0;
                    foreach (string file in resourceFiles)
                    {
                        string fileUrl = CommonUrl + file.Replace("\\", "/");
                        int s = fileUrl.IndexOf("/",7);
                        int e = fileUrl.LastIndexOf("/");
                        string showFileUrl = fileUrl.Substring(0, s + 1) + "..." + fileUrl.Substring(e);
                        DownloadResourceInfo = "正在下载：" + showFileUrl;
                        string path = DownloadPath + "\\" + Path.GetDirectoryName(file);
                        if (!Core.DownloadFileByAria2Async(fileUrl, path))
                        {
                            //MessageBox.Show(fileUrl + "下载失败");

                            Core.WriteErrorlogToFile("error.log", fileUrl + "下载失败");
                        }
                        DownValue = ++i;
                    }
                }
                DownloadResourceInfo = "资源下载完毕。";
                DownBtnContent = "下载";
                DownIsEnable = true;
                DownIsIndicatorVisible = false;
            });
        }


        public void OpenDownPath()
        {
            System.Diagnostics.Process.Start("explorer.exe", DownloadPath);//打开目录
        }


        public void WinClose() => Application.Current.Shutdown();   // C#6的语法, 表达式方法

        public void SelectPath()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;  // 这里一定要设置true，不然就是选择文件
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                Console.WriteLine("选择的目录是:" + path);
                ResourcesPath = path;
                resourceFiles = Core.GetAllFile(_resourcesPath, _resourcesPath);
                ResourceCount = resourceFiles.Count;

                StreamWriter streamWriter = File.CreateText("resourceFiles.txt");
                streamWriter.WriteLine("目录\"" + path + "\" 下的文件如下:");
                streamWriter.WriteLine(string.Join("\n", resourceFiles.ToArray()));
                streamWriter.Close();
            }
        }

        /// <summary>
        /// 清楚选择的资源目录
        /// </summary>
        public void ClearResourceData()
        {
            //resourceFiles = null;
            //ResourceNameIsEnable = true;
            ResourceCount = 0;//以上两个设计已经包含在内
        }

        
        //public void UploadUI(Action action)
        //{
        //    Dispatcher.CurrentDispatcher.BeginInvoke(action);
        //}


    }
}