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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsUtil.WindowLocation
{
    /// <summary>
    /// SetLocation.xaml 的交互逻辑
    /// </summary>
    public partial class SetLocation : Window
    {
        public SetLocation()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Top = Convert.ToInt32(topSlider.Value);
            Left = Convert.ToInt32(leftSlider.Value);
        }
    }
}
