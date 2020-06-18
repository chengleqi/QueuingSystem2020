using System.Windows;
using QueuingSystem2020.Service.IotService;

namespace QueuingSystem2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //开始取号
        private void StartTake_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.StartTake();
        }

        //暂停取号
        private void PauseTake_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.PauseTake();
        }

        //叫号
        private void CallNumber_Click(object sender, RoutedEventArgs e)
        {
            IotPostService.CallNumber();
        }

        //发送消息
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text!="")
            {
                IotPostService.SendMessage(Message.Text);
                MessageBox.Show("发送成功！");
            }
            else
            {
                MessageBox.Show("发送失败", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        //导出图表数据
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //导入图表数据
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
