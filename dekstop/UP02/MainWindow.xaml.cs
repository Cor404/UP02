using System.ComponentModel;
using System.Windows;

namespace UP02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            templ g = new templ();
            g.Show();
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
                //this.Width = SystemParameters.WorkArea.Width;
                //this.Height = SystemParameters.WorkArea.Height;
                //this.Top = SystemParameters.WorkArea.Top; 
                //this.Left = SystemParameters.WorkArea.Left;
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
            this.Opacity = 0.1;
            Users f = new Users();
            f.ShowDialog();
            this.Opacity = 1;
        }
    }
}