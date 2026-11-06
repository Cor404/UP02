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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для cborder.xaml
    /// </summary>
    public partial class cborder : UserControl
    {
        public cborder()
        {
            InitializeComponent();

            el.Width = 100;
            el.Height = 100;

            RadialGradientBrush radialBrush = new RadialGradientBrush();

            radialBrush.Center = new Point(0.5, 0.5);
            radialBrush.RadiusX = 0.5;      
            radialBrush.RadiusY = 0.5;
            radialBrush.GradientOrigin = new Point(0.5, 0.5);

            radialBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0));
            radialBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            el.Fill = radialBrush;

        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;

            Point pos = e.GetPosition(b);

            double x = pos.X;
            double y = pos.Y;

            el.Margin = new Thickness(x, y, 0, 0);
            //el.RenderTransform = new TranslateTransform(x, y);
        }
    }
}
