using System.Windows.Input;

namespace REghZyWPFLib.Core.Menus {
    public interface IContext {
        object Icon { get; set; }

        string Header { get; set; }

        string Gesture { get; set; }

        ICommand Command { get; set; }
    }
}