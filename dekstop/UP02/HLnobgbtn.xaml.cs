using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для HLnobgbtn.xaml
    /// </summary>
    public partial class HLnobgbtn : UserControl
    {
        Effect norm, sel;

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

        public HLnobgbtn()
        {
            InitializeComponent();
            SolidColorBrush orange = (SolidColorBrush)this.FindResource("hl_orange");
            Color orange2 = Color.FromArgb(orange.Color.A, orange.Color.R, orange.Color.G, orange.Color.B);
            SolidColorBrush orange_sel = (SolidColorBrush)this.FindResource("hl_orange_sel");
            Color orange2_sel = Color.FromArgb(orange_sel.Color.A, orange_sel.Color.R, orange_sel.Color.G, orange_sel.Color.B);
            Effect norm = new DropShadowEffect() { Color = orange2, BlurRadius = 40, Opacity = 0.9, ShadowDepth = 0 };
            Effect sel = new DropShadowEffect() { Color = orange2_sel, BlurRadius = 20, Opacity = 1, ShadowDepth = 0 };
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTbl.Opacity = 0.8;
            btnTbl.Foreground = (SolidColorBrush)this.FindResource("hl_orange_sel");
            //btnTbl.Effect = norm;
        }
        private void btnBg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            btnTbl.Opacity = 0.4;
        }

        private void btnBg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            btnTbl.Opacity = 0.6;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTbl.Opacity = 0.6;
            btnTbl.Foreground = (SolidColorBrush)this.FindResource("hl_orange");
            //btnTbl.Effect = sel;
        }
    }
}
