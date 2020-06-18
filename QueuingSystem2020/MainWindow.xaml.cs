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

        private void StartTake_Click(object sender, RoutedEventArgs e)
        {
            IotCmdService.StartTake();
        }

        private void PauseTake_Click(object sender, RoutedEventArgs e)
        {
            IotCmdService.PauseTake();
        }

        private void CallNumber_Click(object sender, RoutedEventArgs e)
        {
            IotCmdService.CallNumber();
        }
    }
}
