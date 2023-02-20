using REghZy.MVVM.Commands;
using REghZyWPFLib.Core.Views;
using System.Windows.Input;
using REghZyWPFLib.Core.Dialogs;

namespace REghZyWPFLib.Example.Users.Modify {
    public class ModifyUserViewModel : BaseDialogViewModel<bool?> {
        private string username;
        public string Username {
            get => this.username;
            set => this.RaisePropertyChanged(ref this.username, value);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public IValidator<ModifyUserViewModel> Validator { get; set; }

        public ModifyUserViewModel(IView<bool?> view) : base(view) {
            this.ConfirmCommand = new RelayCommand(this.ConfirmAction);
            this.CancelCommand = new RelayCommand(this.CancelAction);
        }

        public async void ConfirmAction() {
            if (this.Validator != null) {
                try {
                    this.Validator.Validate(this);
                }
                catch (ValidationFailedException e) {
                    await IoC.MessageDialogs.ShowDialogAsync(e.Caption, e.Message);
                    return;
                }
            }

            this.View.CloseView(true);
        }

        public void CancelAction() {
            this.View.CloseView(false);
        }
    }
}
