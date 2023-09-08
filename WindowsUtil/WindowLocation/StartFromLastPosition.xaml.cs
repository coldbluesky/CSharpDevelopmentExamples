using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using FileOperations;
using System.IO;

namespace WindowsUtil.WindowLocation
{
    /// <summary>
    /// 
    /// </summary>
    public partial class StartFromLastPosition : Window
    {
        public StartFromLastPosition()
        {
            InitializeComponent();
            BasicFileOperations.INICreate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var a = Top;

            Top = Convert.ToDouble(BasicFileOperations.INIRead("main", "top", "./setting.ini"));
            Left = Convert.ToDouble(BasicFileOperations.INIRead("main", "left", "./setting.ini"));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            BasicFileOperations.INIWrite("main","top",Top.ToString(),"./setting.ini");
            BasicFileOperations.INIWrite("main","left",Left.ToString(),"./setting.ini");
        }
    }
}
