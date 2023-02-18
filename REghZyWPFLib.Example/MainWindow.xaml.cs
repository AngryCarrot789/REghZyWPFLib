using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using REghZyWPFLib.Core;
using REghZyWPFLib.Example.Users;
using REghZyWPFLib.Example.Users.Create;

namespace REghZyWPFLib.Example {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();
            IoC.Instance.Register<IUserDialogService>(new UserDialogService());
            this.DataContext = new UserManagerViewModel();
        }
    }
}
