using System.Windows.Input;
using REghZy.MVVM.ViewModels;
using REghZyWPFLib.Core.Menus;

namespace REghZyWPFLib.Example.Users {
    public class UserContextItemViewModel : BaseViewModel, IContext {
        private string header;
        public string Header {
            get => this.header;
            set => this.RaisePropertyChanged(ref this.header, value);
        }

        private string gesture;
        public string Gesture {
            get => this.gesture;
            set => this.RaisePropertyChanged(ref this.gesture, value);
        }

        private ICommand command;
        public ICommand Command {
            get => this.command;
            set => this.RaisePropertyChanged(ref this.command, value);
        }

        private object icon;
        public object Icon {
            get => this.icon;
            set => this.RaisePropertyChanged(ref this.icon, value);
        }

        public UserContextItemViewModel() {

        }

        public UserContextItemViewModel(string header, string gesture = null, ICommand command = null, object icon = null) {
            this.header = header;
            this.gesture = gesture;
            this.command = command;
            this.icon = icon;
        }
    }
}