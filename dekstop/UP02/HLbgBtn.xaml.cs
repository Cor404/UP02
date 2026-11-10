using System.Windows;
using System.Windows.Controls;

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
            typeof(HLnobgbtn),
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
    }
}
