using REghZyWPFLib.Core.Views;

namespace REghZyWPFLib.Example.Users.Modify {
    public class ModifyUserDialogResult : BaseDialogResult<bool> {
        public ModifyUserViewModel ViewModel { get; set; }

        public ModifyUserDialogResult() {

        }
    }
}
