using System.Windows.Input;
using REghZy.MVVM.ViewModels;

namespace REghZyWPFLib.Example.Users {
    public class UserContextItemViewModel : BaseViewModel {
        private string header;
        public string Header {
            get => this.header;
            set => this.RaisePropertyChanged(ref this.header, value);
        }

        private string hint;
        public string Hint {
            get => this.hint;
            set => this.RaisePropertyChanged(ref this.hint, value);
        }

        private ICommand command;
        public ICommand Command {
            get => this.command;
            set => this.RaisePropertyChanged(ref this.command, value);
        }
    }
}