using System.Windows;
using System.Windows.Input;
using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Create {
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window, IView<bool> {
        public NewUserWindow() {
            this.InitializeComponent();
            this.UsernameBox.Focus();
        }

        private void NewUserWindow_OnPreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                e.Handled = true;
                this.CloseDialog(true);
            }
            else if (e.Key == Key.Escape) {
                e.Handled = true;
                this.CloseDialog(false);
            }
        }

        public void CloseDialog(bool result) {
            this.DialogResult = result;
            this.Close();
        }
    }
}
