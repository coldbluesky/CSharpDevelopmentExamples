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
using System.Windows.Forms;


namespace WindowsUtil.WindowLocation
{
    /// <summary>
    /// SetSizeByDesk.xaml 的交互逻辑
    /// </summary>
    public partial class SetSizeByDesk : Window
    {
        public SetSizeByDesk()
        {
            InitializeComponent();
            int deskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int deskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = deskWidth * 0.6;
            this.Height = deskHeight * 0.6;
        }
    }
}
    