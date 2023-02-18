using System.Windows;
using System.Windows.Controls;

namespace REghZyWPFLib.Example.Users {
    public static class UserContextMenuService {
        public static readonly DependencyProperty UserManagerProperty = DependencyProperty.RegisterAttached(
            "UserManager",
            typeof(UserManagerViewModel),
            typeof(ListBox),
            new PropertyMetadata(null));

        public static UserManagerViewModel GetUserManager(ListBox element) {
            return (UserManagerViewModel) element.GetValue(UserManagerProperty);
        }

        public static void SetUserManager(ListBox element, UserManagerViewModel value) {
            element.SetValue(UserManagerProperty, value);

            element.ContextMenuClosing -= OnContextMenuClosing;

            if (value != null) {
                element.ContextMenuClosing += OnContextMenuClosing;
            }

            element.ContextMenuOpening += OnContextMenuOpening;
            if (value != null) {
                element.ContextMenuOpening += OnContextMenuOpening;
            }
        }

        private static void OnContextMenuClosing(object sender, ContextMenuEventArgs e) {
            ListBox box = (ListBox) sender;

            box.ContextMenu?.Items.Clear();
            box.ContextMenu = null;
        }

        private static void OnContextMenuOpening(object sender, ContextMenuEventArgs e) {
            ListBox box = (ListBox) sender;

            box.ContextMenu = new ContextMenu();
            box.ContextMenu.Items.Add(new MenuItem() {
                    Header = "q"
                }
            );
        }
    }
}