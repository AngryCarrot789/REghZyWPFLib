using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Create {
    public class NewUserDialogResult : BaseDialogResult<bool> {
        public NewUserViewModel ViewModel { get; set; }

        public NewUserDialogResult() {

        }
    }
}