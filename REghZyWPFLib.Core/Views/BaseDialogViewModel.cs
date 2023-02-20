using REghZy.MVVM.ViewModels;

namespace REghZyWPFLib.Core.Views {
    public abstract class BaseDialogViewModel<TDialogResult> : BaseViewModel {
        public IView<TDialogResult> View { get; }

        protected BaseDialogViewModel(IView<TDialogResult> view) {
            this.View = view;
        }
    }
}