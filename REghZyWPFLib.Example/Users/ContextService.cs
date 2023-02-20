using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using REghZyWPFLib.Core.Menus;

namespace REghZyWPFLib.Example.Users {
    public static class ContextService {
        public static readonly DependencyProperty UseContextProviderProperty =
            DependencyProperty.RegisterAttached(
                "UseContextProvider",
                typeof(bool),
                typeof(ContextService),
                new FrameworkPropertyMetadata(false, (d, e) => {
                    RegisterRootControl(d, (bool) e.NewValue);
                }));

        public static void SetUseContextProvider(DependencyObject element, bool value) {
            element.SetValue(UseContextProviderProperty, value);
        }

        public static bool GetUseContextProvider(DependencyObject element) {
            return (bool) element.GetValue(UseContextProviderProperty);
        }

        private static void RegisterRootControl(DependencyObject obj, bool add) {
            if (obj is FrameworkElement control) {
                control.PreviewMouseRightButtonUp -= OnContextMenuOpen;
                control.ContextMenuClosing -= OnContextMenuClose;
                if (add) {
                    control.PreviewMouseRightButtonUp += OnContextMenuOpen;
                    control.ContextMenuClosing += OnContextMenuClose;
                }
            }
            else {
                throw new Exception("Invalid target control: " + obj + ". Must be of type " + nameof(FrameworkElement));
            }
        }

        private static void OnContextMenuOpen(object sender, MouseButtonEventArgs mouseButtonEventArgs) {
            if (sender is FrameworkElement control) {
                if (control.DataContext is IContextProvider contextProvider) {
                    ContextMenu menu = control.ContextMenu ?? (control.ContextMenu = new ContextMenu());
                    ItemCollection items = menu.Items;
                    items.Clear();
                    foreach (IContext context in contextProvider.ProvideContext()) {
                        MenuItem item = new MenuItem {
                            Header = context.Header,
                            Command = context.Command,
                            InputGestureText = context.Gesture
                        };

                        items.Add(item);
                    }
                }
            }
        }

        private static void OnContextMenuClose(object sender, ContextMenuEventArgs e) {
            if (sender is FrameworkElement control) {
                if (control.ContextMenu != null)
                    control.ContextMenu.Items.Clear();
                control.ContextMenu = null;
            }
        }
    }
}