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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        SQL c;
        public SignInWindow()
        {
            InitializeComponent();
            tbName.Focus();
            c = new SQL();
            c.TryConnect();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((HLbgBtn)this.Template.FindName("btnCloseWindow", this)).MouseLeftButtonUp += (s, e) =>
            {
                Application.Current.Shutdown();
            };
        }

        public void SignIn()
        {
            MySqlDataReader rd = c.Query("select * from users");
            while (rd.Read())
            {
                if (rd.GetString("uid") == tbName.Text && rd.GetString("pass") == tbPass.Text)
                {
                    MainWindow w = new MainWindow();
                    w.Show();
                    rd.Close();
                    this.Close();
                    return;
                }
            }
            rd.Close();
            HLdialog d = new HLdialog("Введены неверные логин или пароль", HLdialog.EnumMode.OK, "Ошибка");
            d.ShowDialog();
        }

        private void HLbgBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SignIn();
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SignIn();
            }
        }
    }
}
