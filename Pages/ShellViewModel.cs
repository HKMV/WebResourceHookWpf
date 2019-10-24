using System;
using System.Windows;
using Stylet;

namespace WebResourceHookWpf.Pages
{
    public class ShellViewModel : Screen
    {
        public void WinClose() => Application.Current.Shutdown();    // C#6的语法, 表达式方法
    }
}