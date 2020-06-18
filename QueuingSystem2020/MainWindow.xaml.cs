using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Research.DynamicDataDisplay;
using NLECloudSDK;
using QueuingSystem2020.Service.IotService;
using QueuingSystem2020.view;

namespace QueuingSystem2020
{
    public partial class MainWindow
    {
        #region 字段定义

        //图表数据
        private string[] _chartDataArray;

        //导出导入图表数据文件路径
        private readonly string _chartDataPath = ApplicationSettings.Get("ChartDataPath");

        //封装之后的控件
        private readonly DynamicDataDisplay _dynamicDataDisplay = new DynamicDataDisplay();

        //定时常数
        private double _num;

        //plotter显示时的初始横坐标，用于曲线随x轴移动时
        private double _xAxis;

        #endregion

        #region 主窗体函数

        public MainWindow()
        {
            //初始化控件
            InitializeComponent();
            //窗体启动位置位于屏幕中央(同样可在XAML中设置)
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //注册主窗体加载事件
            Loaded += MainWindow_Loaded;
        }

        #endregion

        #region 主窗体加载事件

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化Plotter
            Plotter.AddLineGraph(_dynamicDataDisplay.DataSource, Colors.Red, 2, "历史等待人数");

            //注册定时更新事件
            var timer = new DispatcherTimer(TimeSpan.FromSeconds(5), DispatcherPriority.Normal, updateTime_Tick,
                Dispatcher);
            timer.Start();
        }

        #endregion

        #region 定时更新事件

        private void updateTime_Tick(object sender, EventArgs e)
        {
            #region 更新PeoNumTxt

            var chartDatalist = new List<string>();
            PeoNumTxt.Text = IotGetService.GetNumber().Value.ToString();
            chartDatalist.Add(IotGetService.GetNumber().Value.ToString());
            _chartDataArray = chartDatalist.ToArray();

            #endregion

            #region 更新Plotter

            _num += 5;
            _dynamicDataDisplay.X = _num;
            _dynamicDataDisplay.Y = Double.Parse(IotGetService.GetNumber().Value.ToString());
            if (_num - 50 > 0)
            {
                _xAxis = _num - 50;
            }
            else
            {
                _xAxis = 0;
            }

            //设置Plotter随x轴移动
            Plotter.Viewport.Visible = new Rect(_xAxis, -2, 50, 20);
            _dynamicDataDisplay.AppendAsync(Dispatcher);

            #endregion
        }

        #endregion

        #region 按键功能

        /// <summary>
        /// 开始取号
        /// </summary>
        private void StartTake_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.StartTake();
        }

        /// <summary>
        /// 暂停取号
        /// </summary>
        private void PauseTake_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.PauseTake();
        }

        /// <summary>
        /// 叫号
        /// </summary>
        private void CallNumber_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.CallNumber();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text != "")
            {
                IotPostService.SendMessage(Message.Text);
                MessageBox.Show("发送成功！");
            }
            else
            {
                MessageBox.Show("发送失败", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 导出图表数据
        /// </summary>
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(_chartDataPath, _chartDataArray, Encoding.Default);
            MessageBox.Show("导出成功");
        }

        /// <summary>
        /// 导入图表数据
        /// </summary>
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            _chartDataArray = File.ReadAllLines(_chartDataPath, Encoding.Default);
            _dynamicDataDisplay.X = 0;
            _dynamicDataDisplay.Y = Double.Parse(_chartDataArray[0]);
            _dynamicDataDisplay.AppendAsync(Dispatcher);
        }

        #endregion
    }
}