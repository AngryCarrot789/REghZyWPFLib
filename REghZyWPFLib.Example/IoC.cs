using REghZyWPFLib.Core;
using REghZyWPFLib.Example.Messages;

namespace REghZyWPFLib.Example {
    public static class IoC {
        public static SimpleIoC Instance { get; } = new SimpleIoC();

        public static IMessageDialogService MessageDialogs => Instance.Provide<IMessageDialogService>();
    }
}
