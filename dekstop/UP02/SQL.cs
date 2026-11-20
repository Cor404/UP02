using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            connBuilder.Password = Properties.Settings.Default.pass;

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
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                HLdialog d = new HLdialog(ex.Message, HLdialog.EnumMode.OK, "Ошибка");
                d.ShowDialog();
            }
        }

        public ref MySqlDataReader Query(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                HLdialog d = new HLdialog(ex.Message, HLdialog.EnumMode.OK, "Ошибка");
                d.ShowDialog();
            }
            return ref rd;
        }
        public bool QueryWithoutResult(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                HLdialog d = new HLdialog(ex.Message, HLdialog.EnumMode.OK, "Ошибка");
                d.ShowDialog();
            }
            return false;
        }
    }
}
