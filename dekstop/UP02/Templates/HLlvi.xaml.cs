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

namespace UP02.Templates
{
    /// <summary>
    /// Логика взаимодействия для HLlvi.xaml
    /// </summary>
    public partial class HLlvi : UserControl
    {
        public HLlvi()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Foreground = Brushes.White;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Foreground = (SolidColorBrush)FindResource("hl_win_text_sel");
        }
    }
}
