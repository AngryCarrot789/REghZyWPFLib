namespace REghZyWPFLib.Core.Views {
    public abstract class BaseDialogResult<TDialogResult> {
        /// <summary>
        /// The result of the UI to represent what the user did (e.g confirmed, cancelled, etc)
        /// </summary>
        public TDialogResult DialogResult { get; set; }
    }
}