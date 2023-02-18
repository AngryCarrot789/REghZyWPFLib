namespace REghZyWPFLib.Core.Views {
    /// <summary>
    /// The base class for views, which is typically passed to a ViewModel, in order to access a close function while passing a custom DialogResult
    /// </summary>
    /// <typeparam name="TDialogResult"></typeparam>
    public interface IView<in TDialogResult> {
        void CloseDialog(TDialogResult result);
    }
}