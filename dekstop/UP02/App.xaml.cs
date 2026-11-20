using Org.BouncyCastle.Asn1.X509;
using System.Windows;

namespace UP02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //"DATA_CHECK", "DATA_CHANGE", "DATA_ADD", "DATA_DELETE", "USER_CHECK", "USER_CHANGE", "USER_ADD", "USER_DELETE"

        static private string[] user_perm = new string[] { "DATA_CHECK"};

        static private string[] manager_perm = new string[] { "DATA_CHECK", "DATA_CHANGE", "DATA_ADD", "DATA_DELETE"};

        static private string[] admin_perm = new string[] { "DATA_CHECK", "DATA_CHANGE", "DATA_ADD", "DATA_DELETE", "USER_CHECK", "USER_CHANGE", "USER_ADD", "USER_DELETE"};

        static public string ROLE = "none";

        static public bool roleCheckPermission(string permission)
        {
            if (ROLE == "user")
            {
                for(int i = 0; i < user_perm.Length; i++)
                {
                    if (user_perm[i] == permission)
                    {
                        return true;
                    }
                }
            }
            else if (ROLE == "manager")
            {
                for(int i = 0; i < manager_perm.Length; i++)
                {
                    if (manager_perm[i] == permission)
                    {
                        return true;
                    }
                }
            }
            else if (ROLE == "admin")
            {
                for(int i = 0; i < admin_perm.Length; i++)
                {
                    if (admin_perm[i] == permission)
                    {
                        return true;
                    }
                }
            }
            HLdialog d = new HLdialog("У вас недостаточно прав для этой опции.", HLdialog.EnumMode.OK, "Ошибка");
            d.ShowDialog();
            return false;
        }

        static public string convertRoleToString(string role)
        {
            if(role == "user")
            {
                return "Пользователь";
            }
            else if(role == "manager")
            {
                return "Менеджер";
            }
            else if(role == "admin")
            {
                return "Администратор";
            }

            return "Ошибка конвертации";
        }

    }

}
