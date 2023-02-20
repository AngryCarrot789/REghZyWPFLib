using System.Windows;
using REghZyWPFLib.Example.Messages;
using REghZyWPFLib.Example.Users;

namespace REghZyWPFLib.Example {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();
            IoC.Instance.Register<IUserDialogService>(new UserDialogService());
            IoC.Instance.Register<IMessageDialogService>(new MessageDialogService());
            this.DataContext = new UserManagerViewModel();
        }
    }
}
