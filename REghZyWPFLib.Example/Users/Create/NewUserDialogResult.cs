using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Create {
    public class NewUserDialogResult : BaseDialogResult<bool> {
        public string Username { get; set; }

        public NewUserDialogResult() {

        }
    }
}