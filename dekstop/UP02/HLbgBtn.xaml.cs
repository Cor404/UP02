using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для HLbgBtn.xaml
    /// </summary>
    public partial class HLbgBtn : UserControl
    {

        public static readonly DependencyProperty BLProperty =
        DependencyProperty.Register(
            "BL",
            typeof(bool),
            typeof(HLbgBtn),
            new PropertyMetadata(false, onBLChanged));

        public bool BL
        {
            get => (bool)GetValue(BLProperty);
            set {SetValue(BLProperty, value);}
        }

        public static void onBLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HLbgBtn c = (HLbgBtn)d;
            bool BL = (bool)e.NewValue;
            if (BL)
            {
                c.brdBlck.BorderThickness = new Thickness(1.2);
            }
            else
            {
                c.brdBlck.BorderThickness = new Thickness(0);
            }
        }

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

        public static readonly DependencyProperty WidthProperty =
        DependencyProperty.Register(
            "Width",
            typeof(int),
            typeof(HLbgBtn),
            new PropertyMetadata(int.MinValue));

        public int Width
        {
            get => (int)GetValue(WidthProperty);
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
        DependencyProperty.Register(
            "Height",
            typeof(int),
            typeof(HLbgBtn),
            new PropertyMetadata(int.MinValue));

        public int Height
        {
            get => (int)GetValue(HeightProperty);
            set { SetValue(HeightProperty, value); }
        }

        public HLbgBtn()
        {
            InitializeComponent();
            brdBlck.BorderThickness = new Thickness(0);
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            brdBg.Background = (SolidColorBrush)FindResource("hl_win1");
            brdDarkBorder.BorderThickness = new Thickness(0, 0, 0.5, 0.5);
            brdLightBorder.BorderThickness = new Thickness(0.5, 0.5, 0, 0);
            tblMain.Foreground = Brushes.White;
            ((Grid)sender).ReleaseMouseCapture();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((Grid)sender).CaptureMouse();
            brdBg.Background = (SolidColorBrush)FindResource("hl_win4");
            brdDarkBorder.BorderThickness = new Thickness(0.5, 0.5, 0, 0);
            brdLightBorder.BorderThickness = new Thickness(0, 0, 0.5, 0.5);
            tblMain.Foreground = (SolidColorBrush)FindResource("hl_win2");
        }

        private void TriggerLeftMouseButtonUp(UIElement targetElement)
        {
            // Формируем аргументы события отпускания левой кнопки мыши
            var args = new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton.Left)
            {
                RoutedEvent = UIElement.MouseLeftButtonUpEvent,
                Source = targetElement
            };

            // Генерируем событие на нужном элементе (например, на вашем UserControl)
            targetElement.RaiseEvent(args);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.Key == Key.Enter)
            {
                TriggerLeftMouseButtonUp(this);
            }
        }
    }
}
