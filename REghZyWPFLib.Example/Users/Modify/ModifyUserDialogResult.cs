using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Modify {
    public class ModifyUserDialogResult : BaseDialogResult<bool> {
        public string Username { get; set; }

        public ModifyUserDialogResult() {

        }
    }
}
