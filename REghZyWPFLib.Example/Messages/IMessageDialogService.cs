using System.Threading.Tasks;
using System.Windows;

namespace REghZyWPFLib.Example.Messages {
    public interface IMessageDialogService {
        Task ShowDialogAsync(string caption, string message);
        Task ShowDialogAsync(string message);
    }

    public class MessageDialogService : IMessageDialogService {
        public async Task ShowDialogAsync(string caption, string message) {
            await Application.Current.Dispatcher.InvokeAsync(() => {
                MessageBox.Show(message, caption);
            });
        }

        public async Task ShowDialogAsync(string message) {
            await this.ShowDialogAsync("Information", message);
        }
    }
}