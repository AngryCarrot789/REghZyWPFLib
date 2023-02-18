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
using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Modify {
    /// <summary>
    /// Interaction logic for ModifyUserWindow.xaml
    /// </summary>
    public partial class ModifyUserWindow : Window, IView<bool> {
        public ModifyUserWindow() {
            this.InitializeComponent();
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
