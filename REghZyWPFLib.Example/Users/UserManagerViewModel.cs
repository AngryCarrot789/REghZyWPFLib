using System.Collections.ObjectModel;
using System.Windows.Input;
using REghZy.MVVM.Commands;
using REghZy.MVVM.ViewModels;
using REghZyWPFLib.Example.Users.Create;
using REghZyWPFLib.Example.Users.Modify;

namespace REghZyWPFLib.Example.Users {
    public class UserManagerViewModel : BaseViewModel {
        public ObservableCollection<UserViewModel> Users { get; }

        public ICommand CreateUserCommand { get; }
        public RelayCommandParam<UserViewModel> ModifyUserCommand { get; }
        public RelayCommandParam<UserViewModel> DeleteUserCommand { get; }

        public UserManagerViewModel() {
            this.Users = new ObservableCollection<UserViewModel>();
            this.CreateUserCommand = new RelayCommand(this.CreateUserAction);
            this.ModifyUserCommand = new RelayCommandParam<UserViewModel>(this.ModifyUserAction);
            this.DeleteUserCommand = new RelayCommandParam<UserViewModel>(this.DeleteUserAction);
}
        public void CreateUserAction() {
            IUserDialogService service = IoC.Instance.GetService<IUserDialogService>();
            NewUserDialogResult result = service.CreateUser("Some username");
            if (result.DialogResult) {
                this.Users.Add(new UserViewModel(this) { Username = result.Username});
            }
        }

        public void ModifyUserAction(UserViewModel user) {
            IUserDialogService service = IoC.Instance.GetService<IUserDialogService>();
            ModifyUserDialogResult result = service.ModifyUser(user.Username);
            if (result.DialogResult) {
                user.Username = result.Username;
            }
        }

        public void DeleteUserAction(UserViewModel user) {
            this.Users.Remove(user);
        }
    }
}
