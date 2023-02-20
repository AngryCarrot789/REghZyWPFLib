using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using REghZy.MVVM.Commands;
using REghZy.MVVM.ViewModels;
using REghZyWPFLib.Core.Dialogs;
using REghZyWPFLib.Example.Users.Create;
using REghZyWPFLib.Example.Users.Modify;

namespace REghZyWPFLib.Example.Users {
    public class UserManagerViewModel : BaseViewModel, IValidator<NewUserViewModel>, IValidator<ModifyUserViewModel> {
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
            IUserDialogService service = IoC.Instance.Provide<IUserDialogService>();
            NewUserDialogResult result = service.CreateUser(this, "User " + this.Users.Count);
            if (result.DialogResult) {
                this.Users.Add(new UserViewModel(this) {Username = result.ViewModel.Username});
            }
        }

        public void ModifyUserAction(UserViewModel user) {
            IUserDialogService service = IoC.Instance.Provide<IUserDialogService>();
            ModifyUserDialogResult result = service.ModifyUser(this, user.Username);
            if (result.DialogResult) {
                user.Username = result.ViewModel.Username;
            }
        }

        public void DeleteUserAction(UserViewModel user) {
            this.Users.Remove(user);
        }

        public void Validate(NewUserViewModel data) {
            if (this.Users.Any(a => a.Username == data.Username)) {
                throw new ValidationFailedException("User already exists", $"A user with the name {data.Username} already exists");
            }
        }

        public void Validate(ModifyUserViewModel data) {
            if (this.Users.Any(a => a.Username == data.Username)) {
                throw new ValidationFailedException("Username already in use", $"A user with the name {data.Username} already exists");
            }
        }
    }
}
