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
    /// Логика взаимодействия для HLdialog.xaml
    /// </summary>
    public partial class HLdialog : Window
    {

        public enum EnumResult
        {
            Yes,
            No
        }
        public EnumResult Result = EnumResult.No;

        public enum EnumMode 
        {
            YesNo,
            OK
        }

        public EnumMode Mode = EnumMode.OK;

        public HLdialog(string Text, EnumMode mode, string Title = "Сообщение")
        {
            InitializeComponent();
            MinHeight = Height + 20;
            MinWidth = Width;
            tblText.Text = Text;
            this.Title = Title;
            if (mode == EnumMode.OK)
            {
                btnNo.Opacity = 0;
                btnYes.Opacity = 0;

                btnOK.Focus();
            }
            else
            {
                btnOK.Opacity = 0;
                btnNo.Focus();
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

        private void btnYes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Result = EnumResult.Yes;
            Close();
        }

        private void btnNo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btnOK_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
