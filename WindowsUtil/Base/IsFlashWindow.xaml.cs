using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsUtil.Base
{
    /// <summary>
    /// FlashWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IsFlashWindow : Window
    {
        public IsFlashWindow()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr handle, bool bInvert);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;

            FlashWindow(handle, true);

          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            FlashWindow(handle, false);
        }
    }
}
