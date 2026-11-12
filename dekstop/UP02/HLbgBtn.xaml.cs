using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для HLbgBtn.xaml
    /// </summary>
    public partial class HLbgBtn : UserControl
    {

        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(HLbgBtn),
            new PropertyMetadata(string.Empty));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value); }
        }

        public HLbgBtn()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            brdBg.Background = (SolidColorBrush)FindResource("hl_win1");
            brdDarkBorder.BorderThickness = new Thickness(0, 0, 1, 1);
            brdLightBorder.BorderThickness = new Thickness(1, 1, 0, 0);
            ((Grid)sender).ReleaseMouseCapture();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((Grid)sender).CaptureMouse();
            brdBg.Background = (SolidColorBrush)FindResource("hl_win4");
            brdDarkBorder.BorderThickness = new Thickness(1, 1, 0, 0);
            brdLightBorder.BorderThickness = new Thickness(0, 0, 1, 1);
        }
    }
}
