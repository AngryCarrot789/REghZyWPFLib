using System.Windows.Input;
using REghZy.MVVM.Commands;
using REghZy.MVVM.ViewModels;
using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Create {
    public class NewUserViewModel : BaseViewModel {
        private string username;
        public string Username {
            get => this.username;
            set => this.RaisePropertyChanged(ref this.username, value);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public IView<bool> View { get; }

        public NewUserViewModel(IView<bool> view) {
            this.View = view;
            this.ConfirmCommand = new RelayCommand(this.ConfirmAction);
            this.CancelCommand = new RelayCommand(this.CancelAction);
        }

        public void ConfirmAction() {
            this.View.CloseDialog(true);
        }

        public void CancelAction() {
            this.View.CloseDialog(false);
        }
    }
}