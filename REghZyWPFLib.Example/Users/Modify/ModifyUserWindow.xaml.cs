using System.Windows;
using System.Windows.Input;
using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Modify {
    /// <summary>
    /// Interaction logic for ModifyUserWindow.xaml
    /// </summary>
    public partial class ModifyUserWindow : Window, IView<bool?> {
        public ModifyUserWindow() {
            this.InitializeComponent();
        }

        private void NewUserWindow_OnPreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                e.Handled = true;
                ((ModifyUserViewModel) this.DataContext).ConfirmAction();
            }
            else if (e.Key == Key.Escape) {
                e.Handled = true;
                ((ModifyUserViewModel) this.DataContext).CancelAction();
            }
        }

        public void CloseView(bool? result) {
            this.DialogResult = result;
            this.Close();
        }
    }
}
