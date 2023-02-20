using System.Windows;
using System.Windows.Input;
using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Create {
    /// <summary>
    /// Interaction logic for NewUserWindow.xaml
    /// </summary>
    public partial class NewUserWindow : Window, IView<bool?> {
        public NewUserWindow() {
            this.InitializeComponent();
        }

        private void NewUserWindow_OnPreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                e.Handled = true;
                ((NewUserViewModel) this.DataContext).ConfirmAction();
            }
            else if (e.Key == Key.Escape) {
                e.Handled = true;
                ((NewUserViewModel) this.DataContext).CancelAction();
            }
        }

        public void CloseView(bool? result) {
            this.DialogResult = result;
            this.Close();
        }
    }
}
