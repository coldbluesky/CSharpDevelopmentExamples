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
using WindowsUtil.WindowLocation;

namespace WindowsUtil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetLocationClick(object sender, RoutedEventArgs e)
        {
            SetLocation w = new SetLocation();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        private void StartFormLastLocationClick(object sender, RoutedEventArgs e)
        {
            StartFromLastPosition w = new StartFromLastPosition();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        private void AlwaysTopShowClick(object sender, RoutedEventArgs e)
        {

            AlwaysTopShow w = new AlwaysTopShow();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        private void SetSizeByDeskClick(object sender, RoutedEventArgs e)
        {
            SetSizeByDesk w = new SetSizeByDesk();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }
    }
}
