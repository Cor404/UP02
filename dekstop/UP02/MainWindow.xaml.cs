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
            Users f = new Users();
            f.Show();

            templ g = new templ();
            g.Show();
        }

        private void HLnobgbtn_Exit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}