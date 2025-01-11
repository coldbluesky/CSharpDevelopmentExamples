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

namespace WindowsUtil.Base
{
    /// <summary>
    /// CustomChangeWindowSize.xaml 的交互逻辑
    /// 定义两个私有属性，标志初始坐标和是否改变大小
    /// 建立三个方法对应鼠标按下，鼠标移动，鼠标释放
    /// 鼠标按下，改变大小为true，记录鼠标的坐标
    /// 鼠标移动，改变大小为true才执行，记录鼠标当前坐标，计算当前坐标与初始坐标x轴和y轴的差，窗口宽度和高度分别加上x轴和y轴的差，初始坐标重置为当前坐标
    /// 鼠标释放，改变大小为false
    /// </summary>
    public partial class CustomChangeWindowSize : Window
    {
        public CustomChangeWindowSize()
        {
            InitializeComponent();
            LostFocus += (s,e) => isResize = false;
            MouseLeave += (s,e) => isResize = false;
        }
        private bool isResize;
        private Point startPoint;
        private ResizeDirection direction;
        public void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            //if(e.LeftButton == MouseButtonState.Pressed )
            //{
                startPoint = e.GetPosition(this);

                //double leftDistance = startPoint.X;
                //double rightDistance = Width - startPoint.X;
                //double topDistance = startPoint.Y;
                //double buttomDistance = Height - startPoint.Y ;
                //double resizeRegion = 80;
                //if (leftDistance < resizeRegion)
                //{
                //    direction = ResizeDirection.Left;
                //}
                //else if (rightDistance < resizeRegion)
                //{
                //    direction = ResizeDirection.Right;
                //}
                //else if(topDistance < resizeRegion+50)
                //{
                //    direction = ResizeDirection.Top;
                //}
                //else if (buttomDistance < resizeRegion)
                //{
                //    direction = ResizeDirection.Bottom;
                //}
                isResize = true;
            //}
           
        }     
        public void Mouse_Move(object sender,MouseEventArgs e)
        {
            if (isResize)
            {
                Point currentPonit = e.GetPosition(this);
                
                double deltaX = currentPonit.X - startPoint.X;
                double deltaY = currentPonit.Y - startPoint.Y;
                //switch (direction)
                //{
                //    case ResizeDirection.Left:
                //        Left += deltaX;
                //        Width -= deltaX;
                //        break;
                //    case ResizeDirection.Right:
                //        Width += deltaX;
                //        break;
                //    case ResizeDirection.Top:
                //        Top += deltaY;
                //        Height -= deltaX;
                //        break;
                //    case ResizeDirection.Bottom:
                //        Height += deltaY;
                //        break;
                //    default:
                //        break;
                //}
                

                Width += deltaX;
                Height += deltaY;
                startPoint = currentPonit;
                

            }

        }
        public void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            isResize = false;
        }
    }
    public enum ResizeDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
