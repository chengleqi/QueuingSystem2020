using System.Windows;
using NLECloudSDK;
using QueuingSystem2020.Service.LoginService;

namespace QueuingSystem2020
{
    public partial class Login
    {
        #region 登录窗体函数

        public Login()
        {
            //初始化控件
            InitializeComponent();
            //窗体启动位置位于屏幕中央(同样可在XAML中设置)
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        #endregion

        #region 登录按键

        /// <summary>
        /// 登录
        /// </summary>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginService.UserLogin(new AccountLoginDTO
                {Account = UsernameBox.Text.Trim(), Password = PasswordBox.Password}))
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("登录失败", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion
    }
}