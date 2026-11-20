using System.Windows;

namespace UP02.Templates
{
    public partial class HLWin : ResourceDictionary
    {
        public HLWin()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window a = Window.GetWindow(((HLbgBtn)sender));
            a.Close();
        }
    }
}
