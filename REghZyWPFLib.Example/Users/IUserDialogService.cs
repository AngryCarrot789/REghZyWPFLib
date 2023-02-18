using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using REghZyWPFLib.Example.Users.Create;
using REghZyWPFLib.Example.Users.Modify;

namespace REghZyWPFLib.Example.Users {
    public interface IUserDialogService {
        Task<NewUserDialogResult> CreateUserAsync(string username = null, bool selectName = true);

        NewUserDialogResult CreateUser(string username = null, bool selectName = true);

        Task<ModifyUserDialogResult> ModifyUserAsync(string username = null, bool selectName = true);

        ModifyUserDialogResult ModifyUser(string username = null, bool selectName = true);
    }

    public class UserDialogService : IUserDialogService {
        public async Task<NewUserDialogResult> CreateUserAsync(string username = null, bool selectName = true) {
            Dispatcher dispatcher = Application.Current?.Dispatcher;
            if (dispatcher == null) {
                return new NewUserDialogResult() {DialogResult = false};
            }

            return await dispatcher.InvokeAsync(() => this.CreateUser(username, selectName));
        }

        public NewUserDialogResult CreateUser(string username = null, bool selectName = true) {
            NewUserWindow window = new NewUserWindow();
            NewUserViewModel viewModel = new NewUserViewModel(window) {
                Username = username ?? ""
            };

            window.DataContext = viewModel;
            if (selectName) {
                Application.Current.Dispatcher.Invoke(() => {
                    window.UsernameBox.Focus();
                    window.UsernameBox.SelectAll();
                }, DispatcherPriority.Loaded);
            }

            bool result = window.ShowDialog() == true;

            return new NewUserDialogResult {
                Username = viewModel.Username,
                DialogResult = result
            };
        }

        public async Task<ModifyUserDialogResult> ModifyUserAsync(string username = null, bool selectName = true) {
            Dispatcher dispatcher = Application.Current?.Dispatcher;
            if (dispatcher == null) {
                return new ModifyUserDialogResult() {DialogResult = false};
            }

            return await dispatcher.InvokeAsync(() => this.ModifyUser(username, selectName));
        }

        public ModifyUserDialogResult ModifyUser(string username = null, bool selectName = true) {
            ModifyUserWindow window = new ModifyUserWindow();
            ModifyUserViewModel viewModel = new ModifyUserViewModel(window) {
                Username = username ?? ""
            };

            window.DataContext = viewModel;
            if (selectName) {
                Application.Current.Dispatcher.Invoke(() => {
                    window.UsernameBox.Focus();
                    window.UsernameBox.SelectAll();
                }, DispatcherPriority.Loaded);
            }

            bool result = window.ShowDialog() == true;

            return new ModifyUserDialogResult {
                Username = viewModel.Username,
                DialogResult = result
            };
        }
    }
}