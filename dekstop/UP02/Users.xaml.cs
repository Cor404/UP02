using MySql.Data.MySqlClient;
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

namespace UP02
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        SQL c;
        public Users()
        {
            InitializeComponent();
            c.TryConnect();
            MySqlDataReader rd;
            rd = c.Query("select * from users");
            while (rd.Read())
            {
                ListViewItem i = new ListViewItem();
                i.Style = (Style)FindResource("HLlvi");
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HLbgBtn a = this.Template.FindName("btnCloseWindow", this) as HLbgBtn;
            a.MouseLeftButtonUp += (s, e) =>
            {
                Close();
            };
        }
    }
}
