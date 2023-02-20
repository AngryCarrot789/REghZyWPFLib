using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using REghZyWPFLib.Core.Dialogs;
using REghZyWPFLib.Example.Users.Create;
using REghZyWPFLib.Example.Users.Modify;

namespace REghZyWPFLib.Example.Users {
    public interface IUserDialogService {
        Task<NewUserDialogResult> CreateUserAsync(IValidator<NewUserViewModel> validator, string username = null, bool selectName = true);

        NewUserDialogResult CreateUser(IValidator<NewUserViewModel> validator, string username = null, bool selectName = true);

        Task<ModifyUserDialogResult> ModifyUserAsync(IValidator<ModifyUserViewModel> validator, string username = null, bool selectName = true);

        ModifyUserDialogResult ModifyUser(IValidator<ModifyUserViewModel> validator, string username = null, bool selectName = true);
    }

    public class UserDialogService : IUserDialogService {
        public async Task<NewUserDialogResult> CreateUserAsync(IValidator<NewUserViewModel> validator, string username = null, bool selectName = true) {
            Dispatcher dispatcher = Application.Current?.Dispatcher;
            if (dispatcher == null) {
                return new NewUserDialogResult() {DialogResult = false};
            }

            return await dispatcher.InvokeAsync(() => this.CreateUser(validator, username, selectName));
        }

        public NewUserDialogResult CreateUser(IValidator<NewUserViewModel> validator, string username = null, bool selectName = true) {
            NewUserWindow window = new NewUserWindow();
            NewUserViewModel context = new NewUserViewModel(window){
                Validator = validator,
                Username = username
            };

            window.DataContext = context;

            if (selectName) {
                Application.Current.Dispatcher.Invoke(() => {
                    window.UsernameBox.Focus();
                    window.UsernameBox.SelectAll();
                }, DispatcherPriority.Loaded);
            }

            bool result = window.ShowDialog() == true;

            return new NewUserDialogResult {
                ViewModel = context,
                DialogResult = result
            };
        }

        public async Task<ModifyUserDialogResult> ModifyUserAsync(IValidator<ModifyUserViewModel> validator, string username = null, bool selectName = true) {
            Dispatcher dispatcher = Application.Current?.Dispatcher;
            if (dispatcher == null) {
                return new ModifyUserDialogResult() {DialogResult = false};
            }

            return await dispatcher.InvokeAsync(() => this.ModifyUser(validator, username, selectName));
        }

        public ModifyUserDialogResult ModifyUser(IValidator<ModifyUserViewModel> validator, string username = null, bool selectName = true) {
            ModifyUserWindow window = new ModifyUserWindow();
            ModifyUserViewModel context = new ModifyUserViewModel(window) {
                Validator = validator,
                Username = username
            };

            window.DataContext = context;

            if (selectName) {
                Application.Current.Dispatcher.Invoke(() => {
                    window.UsernameBox.Focus();
                    window.UsernameBox.SelectAll();
                }, DispatcherPriority.Loaded);
            }

            bool result = window.ShowDialog() == true;

            return new ModifyUserDialogResult {
                ViewModel = context,
                DialogResult = result
            };
        }
    }
}