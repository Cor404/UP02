using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UP02
{
    internal class SQL
    {
        MySqlConnection conn;
        MySqlConnectionStringBuilder connBuilder;
        MySqlDataReader rd;
        MySqlCommand cmd;
        public SQL()
        {

            connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.Server = Properties.Settings.Default.host;
            connBuilder.UserID = Properties.Settings.Default.uid;
            connBuilder.Database = Properties.Settings.Default.db;
            connBuilder.Password = "";

        }

        public ref MySqlConnection Connection
        {
            get
            {
                return ref conn;
            }
        }

        public bool TryConnect()
        {
            conn = new MySqlConnection(connBuilder.ConnectionString.ToString());

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                HLdialog d = new HLdialog(ex.Message, HLdialog.EnumMode.OK, "Ошибка");
                d.ShowDialog();
                return false;
            }
            return true;
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public ref MySqlDataReader Query(string query)
        {
            cmd = new MySqlCommand(query, conn);
            rd = cmd.ExecuteReader();
            return ref rd;
        }

    }
}
