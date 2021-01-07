using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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
        /// 资源获取模块是否可以操作
        /// </summary>
        private bool _resIsEnable = true;
        public bool ResIsEnable { get { return _resIsEnable; } set { _resIsEnable = value; } }

        /// <summary>
        /// 资源路径
        /// </summary>
        private string _resourcesPath = null;
        public string ResourcesPathToolTip { get { return _resourcesPath; } set { _resourcesPath = value; } }
        public string ResourcesPath
        {
            get
            {
                string show = _resourcesPath;
                if (null != show && show.Contains("\\"))
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
                ResourcesPathToolTip = value;
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
        public string DownloadResourceInfoToolTip { get { return _downloadResourceInfo; } set { _downloadResourceInfo = value; } }
        public string DownloadResourceInfo
        {
            get
            {
                if (_downloadResourceInfo != null && _downloadResourceInfo.Contains("/"))
                {
                    int s = _downloadResourceInfo.IndexOf("/", 7);
                    int e = _downloadResourceInfo.LastIndexOf("/");
                    return _downloadResourceInfo.Substring(0, s + 1) + "..." + _downloadResourceInfo.Substring(e);
                }
                return _downloadResourceInfo;
            }
            set
            {
                if (_downloadResourceInfo == value)
                {
                    return;
                }
                DownloadResourceInfoToolTip = value;
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

        public string _downBtnContent = "下载";
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


        #region 上传资源到七牛云

        public bool _upIsEnable = true;
        public bool UpIsEnable { get { return _upIsEnable; } set { _upIsEnable = value; } }


        public string _accessKey = "";
        public string AccessKey
        {
            get
            {
                if (QiniuHelp.Settings.AccessKey != _accessKey)
                {
                    QiniuHelp.Settings.AccessKey = _accessKey;
                }
                return _accessKey;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                _accessKey = value;
                QiniuHelp.Settings.AccessKey = value;
            }
        }

        public string _secretKey = "";
        public string SecretKey
        {
            get
            {
                if (QiniuHelp.Settings.SecretKey != _secretKey)
                {
                    QiniuHelp.Settings.SecretKey = _secretKey;
                }
                return _secretKey;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                _secretKey = value;
                QiniuHelp.Settings.SecretKey = value;
            }
        }

        public string _bucket = "";
        public string Bucket
        {
            get { return _bucket; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                _bucket = value;
            }
        }

        public string _upResourceInfo = "";
        public string UpResourceInfo { get { return _upResourceInfo; } set { _upResourceInfo = value; } }

        public string _upBtnContent = "上传";
        public string UpBtnContent { get { return _upBtnContent; } set { _upBtnContent = value; } }


        #endregion 上传资源到七牛云

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
                ResIsEnable = false;
                DownIsEnable = false;
                DownIsIndicatorVisible = true;
                DownMin = 0;
                DownBtnContent = "下载中···";
                int errorFlag = 0;
                if (ResourceNameIsEnable)
                {
                    DownMax = 2;
                    DownValue = 1;

                    string url = CommonUrl + ResourceName;
                    //MessageBox.Show("完整地址：" + url);
                    //DownloadResourceInfo = "正在下载：" + url.Substring(0, url.IndexOf("/", 7) + 1) + "..." + url.Substring(url.LastIndexOf("/"));
                    DownloadResourceInfo = "正在下载：" + url;
                    if (!Core.DownloadFileByAria2(url, DownloadPath))
                    {
                        ++errorFlag;
                        Core.WriteErrorlogToFile("error.log", url + "下载失败");
                    }
                    //MessageBox.Show("下载是否成功：" + downloadFileByAria2Async);
                    DownValue = 2;
                }
                else
                {
                    DownMax = resourceFiles.Count;
                    int i = 0;
                    foreach (string filePath in resourceFiles)
                    {
                        string fileUrl = CommonUrl + filePath.Replace("\\", "/");
                        //int s = fileUrl.IndexOf("/", 7);
                        //int e = fileUrl.LastIndexOf("/");
                        //string showFileUrl = fileUrl.Substring(0, s + 1) + "..." + fileUrl.Substring(e);
                        DownloadResourceInfo = "正在下载：" + fileUrl;
                        string fileLocalPath = DownloadPath + "\\" + Path.GetDirectoryName(filePath);
                        fileLocalPath = Core.CorrectionPath(fileLocalPath);

                        downFile(fileUrl, fileLocalPath, ref errorFlag);

                        DownValue = ++i;
                    }
                }
                if (errorFlag > 0)
                {
                    DownloadResourceInfo = "有" + errorFlag + "个资源下载失败，请查看error.log日志文件。";
                }
                else
                {
                    DownloadResourceInfo = "资源下载完毕。";
                }

                DownBtnContent = "下载";
                ResIsEnable = true;
                DownIsEnable = true;
                DownIsIndicatorVisible = false;
            });
        }
        /// <summary>
        /// 校验数据是否正确
        /// </summary>
        /// <param name="fileLocalAllPath">文件本地全路径</param>
        /// <returns></returns>
        private bool checkDownFile(string fileLocalAllPath)
        {
            string extenName = Path.GetExtension(fileLocalAllPath);
            if (!File.Exists(fileLocalAllPath))
            {
                return false;
            }

            StreamReader streamReader = new StreamReader(new FileStream(fileLocalAllPath, FileMode.Open, FileAccess.Read), Encoding.UTF8);
            string lineText = streamReader.ReadLine();
            streamReader.Close();
            // string checkText = lineText.Substring(0, 3);
            bool isOk = false;
            Regex regChina = new Regex("[^\x00-\xFF]+");//匹配中文或是乱码，这里不存在中文，所以为乱码
            switch (extenName)
            {
                case ".js":
                {
                    bool isError = regChina.IsMatch(lineText);
                    isOk = !isError;
                    break;
                }
                case ".css":
                {
                    bool isError = regChina.IsMatch(lineText);
                    isOk = !isError;
                    break;
                }
                case ".png":
                {
                    isOk = lineText.Contains(FileHeadEnum.PNG.GetRemark());
                    break;
                }
                case ".json":
                {
                    string readAllText = File.ReadAllText(fileLocalAllPath);
                    bool isJson = JsonSplit.IsJson(readAllText);
                    isOk = isJson;
                    break;
                }
                case ".dds":
                {
                    isOk = lineText.Contains(FileHeadEnum.DDS.GetRemark());
                    break;
                }
                default:
                {
                    isOk = true;
                    break;
                }
            }
            return isOk;
        } 

        /// <summary>
        /// 下载并校验文件
        /// </summary>
        /// <param name="fileUrl">文件网络地址</param>
        /// <param name="fileLocalPath">文件本地存放目录（不含文件名）</param>
        /// <param name="errorFlag">失败标记位</param>
        private void downFile(string fileUrl,string fileLocalPath, ref int errorFlag)
        {
            try
            {
                if (!Core.DownloadFileByAria2(fileUrl, fileLocalPath))
                {
                    //MessageBox.Show(fileUrl + "下载失败");
                    ++errorFlag;
                    Core.WriteErrorlogToFile("error.log", fileUrl + "下载失败");
                }
                else
                {
                    string fileName = Path.GetFileName(fileUrl);
                    string fileLocalAllPath = fileLocalPath+fileName;
                    if (!checkDownFile(fileLocalAllPath))
                    {
                        File.Delete(fileLocalAllPath);
                        downFile(fileUrl, fileLocalPath, ref errorFlag);
                    }
                }
            }
            catch (Exception e)
            {
                errorFlag = ++errorFlag;
                Core.WriteErrorlogToFile("error.log", fileUrl + "下载失败。" + e.Message);
            }
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

        public void ImportFromFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("列表文件", "*.list"));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                Console.WriteLine("选择的文件是:" + path);
                string[] files = File.ReadAllLines(path);
                if (files.Length > 0)
                {
                    ResourcesPath = "已从文件导入,可重新选择文件夹。";
                    resourceFiles = new List<string>(files);
                    string s = files[0];
                    if (s.Contains("目录") || s.Contains("文件如下"))
                    {
                        resourceFiles.RemoveAt(0);
                    }
                    ResourceCount = resourceFiles.Count;
                }
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

        public void SelectResource()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;  // 这里一定要设置true，不然就是选择文件
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                Console.WriteLine("选择的目录是:" + path);
                UpResourceInfo = path;
            }
        }

        public void UpResource()
        {
            Task.Run(async () =>
            {
                if (Directory.Exists(UpResourceInfo))
                {
                    UpIsEnable = false;
                    UpBtnContent = "上传中...";
                    string[] files = Directory.GetFiles(UpResourceInfo, "*", SearchOption.AllDirectories);

                    string path = UpResourceInfo.Substring(UpResourceInfo.LastIndexOf("\\") + 1);
                    foreach (var file in files)
                    {
                        int num = file.IndexOf(path);
                        //num = num < 0 ? 0 : num;
                        string key = file.Substring(num).Replace("\\", "/");
                        UpResourceInfo = "正在上传：" + key;
                        key = "resources/" + key;//决定了上传成功后的文件所在位置
                        string res = await QiniuHelp.UploadFileAsync(Bucket, key, file);
                        Console.WriteLine("上传成功:" + res);
                    };
                    UpResourceInfo = "上传完成。";
                    UpIsEnable = true;
                    UpBtnContent = "上传";
                }
                else
                {
                    UpResourceInfo = "请重新选择要上传的目录！";
                }
            });
        }


    }
}