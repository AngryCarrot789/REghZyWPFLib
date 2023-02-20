using System.Windows.Input;
using REghZy.MVVM.Commands;
using REghZyWPFLib.Core.Dialogs;
using REghZyWPFLib.Core.Views;
using REghZyWPFLib.Example.Messages;

namespace REghZyWPFLib.Example.Users.Create {
    public class NewUserViewModel : BaseDialogViewModel<bool?> {
        private string username;
        public string Username {
            get => this.username;
            set => this.RaisePropertyChanged(ref this.username, value);
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        /// <summary>
        /// A validator, used to validate the state of this instance
        /// </summary>
        public IValidator<NewUserViewModel> Validator { get; set; }

        public NewUserViewModel(IView<bool?> view) : base(view) {
            this.ConfirmCommand = new RelayCommand(this.ConfirmAction);
            this.CancelCommand = new RelayCommand(this.CancelAction);
        }

        public async void ConfirmAction() {
            if (this.Validator != null) {
                try {
                    this.Validator.Validate(this);
                }
                catch (ValidationFailedException e) {
                    await IoC.Instance.Provide<IMessageDialogService>().ShowDialogAsync(e.Caption, e.Message);
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