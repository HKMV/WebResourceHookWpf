using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebResourceHookWpf.Lib;

namespace WebResourceHookWpf.Pages
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            DataContext = this;
            DownResInfo.DataContext = new Core();
        }

        #region 资源绑定

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

        #endregion 资源绑定

        private void DownloadResource(object sender, RoutedEventArgs e)
        {
            string url = CommonUrl + ResourceName;
            MessageBox.Show("完整地址：" + url);
            bool downloadFileByAria2Async = Core.DownloadFileByAria2Async(url, DownloadPath);
            MessageBox.Show("下载是否成功：" + downloadFileByAria2Async);
        }

        #region 窗口相关

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception)
            {
                Console.WriteLine("窗口移动时出现点小问题！");
            }
        }

        private void WinClose(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                Console.WriteLine("关闭程序时出现了点小问题！");
            }
        }

        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion 窗口相关

        private void OpenDownPath(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start(v_OpenFilePath);//打开文件
            System.Diagnostics.Process.Start("explorer.exe", DownloadPath);//打开目录
        }
    }
}