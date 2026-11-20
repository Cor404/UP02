using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
    /// 

    public partial class userLvi : ListViewItem
    {

        public string key;

        public userLvi(string uid, string pass, string role, string key = "none") { 
            Style = (Style)FindResource("HLlvi_user");

            ApplyTemplate();

            ((TextBlock)this.Template.FindName("tbUserUid", this)).Text = uid;
            ((TextBlock)this.Template.FindName("tbUserPass", this)).Text = pass;
            ((TextBlock)this.Template.FindName("tbUserRole", this)).Text = role;
            this.key = key;
        }
    }

    public partial class Users : Window
    {
        SQL c;
        public Users()
        {
            InitializeComponent();
            c = new SQL();
            c.TryConnect();
            lvFill();
        }

        public int getCbIndex(string role)
        {
            if (role == "user")
            {
                return 0;
            }
            else if (role == "manager")
            {
                return 1;
            }
            else if(role == "admin")
            {
                return 2;
            }
            return -1;
        }

        public string getCbRole(int index)
        {
            if (index == 0)
            {
                return "user";
            }
            else if (index == 1)
            {
                return "manager";
            }
            else if (index == 2)
            {
                return "admin";
            }
            return "none";
        }

        public void lvFill()
        {
            lvUsers.Items.Clear();

            lvUsers.Items.Add(new userLvi("Логин", "Пароль", "Роль", "HEAD"));

            MySqlDataReader rd;
            rd = c.Query("select * from users");
            while (rd.Read())
            {
                string uid = rd.GetString(0), pass = rd.GetString(1), role = rd.GetString(2);
                userLvi i = new userLvi(uid, pass, role);
                i.MouseDoubleClick += (s, e) =>
                {
                    tbUserName.Text = uid;
                    tbUserPass.Text = pass;
                    cbUserRole.SelectedIndex = getCbIndex(role);
                };
                lvUsers.Items.Add(i);
            }
            rd.Close();
        }

        private void btnUserAdd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string uid = tbUserName.Text, pass = tbUserPass.Text, role = getCbRole(cbUserRole.SelectedIndex);

            MySqlDataReader dr;

            dr = c.Query("select * from users");

            while (dr.Read())
            {
                if (dr.GetString("uid") == uid)
                {
                    dr.Close();
                    HLdialog d = new HLdialog("Пользователь с таким логином уже существует!", HLdialog.EnumMode.OK, "Ошибка");
                    d.ShowDialog();
                    break;
                }
            }
            dr.Close();
            if(c.QueryWithoutResult($"insert into users value('{uid}', '{pass}', '{role}');"))
            {
                HLdialog d = new HLdialog($"Пользователь '{uid}' успешно добавлен!", HLdialog.EnumMode.OK);
                d.ShowDialog();
                lvFill();
            }
        }
    }
}
