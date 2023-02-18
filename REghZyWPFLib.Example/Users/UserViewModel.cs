using System.Windows.Input;
using REghZy.MVVM.Commands;
using REghZy.MVVM.ViewModels;

namespace REghZyWPFLib.Example.Users {
    public class UserViewModel : BaseViewModel {
        private string username;
        public string Username {
            get => this.username;
            set => this.RaisePropertyChanged(ref this.username, value);
        }

        public ICommand ModifyCommand { get; }

        public ICommand DeleteCommand { get; }

        public UserManagerViewModel Manager { get; }

        public UserViewModel(UserManagerViewModel manager) {
            this.Manager = manager;
            this.ModifyCommand = new RelayCommand(() => { this.Manager.ModifyUserAction(this); });
            this.DeleteCommand = new RelayCommand(() => { this.Manager.DeleteUserAction(this); });
        }
    }
}
