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
using WindowsUtil.Base;
using System.Threading;
using PropertyChanged;
using System.ComponentModel;
using FreeSql;
using MySql.Data.MySqlClient;

namespace WindowsUtil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Left = SystemParameters.WorkArea.Right - this.Width - 3;
            this.Top = SystemParameters.WorkArea.Bottom - this.Height - 3;
        }

        private void SetLocationClick(object sender, RoutedEventArgs e)
        {
            SetLocation w = new SetLocation();
            //w.WindowStartupLocation = WindowStartupLocation.CenterScreen
            w.Left = SystemParameters.WorkArea.Right - this.Width; // 设置左边距
            w.Top = 1;
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
        private void CutomChangeWindowSizeClick(object sender, RoutedEventArgs e)
        {
            CustomChangeWindowSize w = new CustomChangeWindowSize();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }


        private void CutomChangeWindowSizeClick2(object sender, RoutedEventArgs e)
        {
            CustomChangeWindowSize2 w = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            w.Show();
        }

        private void ThreadPulse(object sender, RoutedEventArgs e)
        {
            lock (lockObject)
            {
                // 设置yourBoolField为true
                yourBoolField = false;

                // 通知等待线程继续执行
                Monitor.PulseAll(lockObject);
            }
        }

        private object lockObject = new object();
        private bool yourBoolField = true;




        private void WaitForBoolField()
        {
            lock (lockObject)
            {
                while (yourBoolField)
                {
                    // 等待yourBoolField变为true
                    Monitor.Wait(lockObject);
                }
            }
        }

        private void ThreadStart(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                MessageBox.Show("线程开始");
                WaitForBoolField();
                MessageBox.Show("线程继续辣！！！！");
                yourBoolField = true;
            });
        }
        public string TestText { get; set; } = "未改变";
        private void TestFody(object sender, RoutedEventArgs e)
        {
            TestText = "已改变";
        }

        private void FreesqlTest(object sender, RoutedEventArgs e)
        {
            using (var freeSql = new FreeSqlBuilder()
                       .UseConnectionFactory(DataType.MySql, () => new MySqlConnection("server=127.0.0.1;database=langtian;port=3308;uid=root;pwd=123456;"))
                       .Build())
            {
                if (freeSql.Ado.ExecuteConnectTest())
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
        }

        private void FlashClick(object sender, RoutedEventArgs e)
        {
            IsFlashWindow w = new IsFlashWindow();
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }

        private void CatchGlobleExceptions(object sender, RoutedEventArgs e)
        {
            string a = null;
            a.Trim();
        }

        private int count = 0;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
            }
        }
        CancellationTokenSource cancellationToken = new CancellationTokenSource();

        private void CancelThread(object sender, RoutedEventArgs e)
        {
            cancellationToken.Cancel();
            cancellationToken.Token.ThrowIfCancellationRequested();
        }

        private void StartThreadWithToken(object sender, RoutedEventArgs e)
        {

            Task.Factory.StartNew(() =>
            {
                try
                {

                    Thread.Sleep(200);
                    Count += 1;
                    Thread.Sleep(5000);
                    Count += 1;

                }
                catch (Exception)
                {

                    MessageBox.Show("线程被取消");
                }


            }, cancellationToken.Token);
        }

        public TestType? CoilType { get; set; } = TestType.单;

    }

    public enum TestType
    {
        单,
        双
    }
}
