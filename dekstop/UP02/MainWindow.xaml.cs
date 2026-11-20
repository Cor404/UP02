using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace UP02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string role)
        {
            InitializeComponent();
            App.ROLE = role;
            tblUserRole.Text = "Права доступа - " + App.convertRoleToString(role);
            HLload l = new HLload();
            l.ShowDialog();

            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(0.5);
            tmr.Tick += (s,e) =>
            {
                tblTime.Text = DateTime.Now.ToString();
            };
            tmr.Start();
        }

        private void HLnobgbtn_Exit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HLnobgbtn_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        private void HLnobgbtn_MouseLeftButtonUp_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void winBtnMaximize_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Current.Shutdown();
        }

        private void HLnobgbtn_MouseLeftButtonUp_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(App.roleCheckPermission("USER_CHECK"))
            {
                Opacity = 0.8;
                Users f = new Users();
                f.ShowDialog();
                Opacity = 1;
            }
        }
    }
}