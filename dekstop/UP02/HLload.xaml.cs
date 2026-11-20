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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для HLload.xaml
    /// </summary>
    public partial class HLload : Window
    {
        int tick = 0;
        public HLload()
        {
            InitializeComponent();
            DispatcherTimer tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(0.1);
            tmr.Tick += Tick;
            tmr.Start();
        }

        public void Tick(object s, EventArgs e)
        {
            tick++;
            if (prgMain.Value < 10) prgMain.Value += 2;
            if (prgMain.Value < 20 && prgMain.Value >= 10) prgMain.Value += 4;
            if (prgMain.Value < 22 && prgMain.Value >= 20) prgMain.Value += 0.5;
            if (prgMain.Value < 60 && prgMain.Value >= 22) prgMain.Value += 5;
            if (prgMain.Value < 100 && prgMain.Value >= 60) prgMain.Value += 20;
            if (prgMain.Value == 100) { ((DispatcherTimer)s).Stop(); this.Close(); }
        }
    }
}
