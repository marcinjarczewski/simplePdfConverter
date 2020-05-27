using Caliburn.Micro;
using pdfConverter.Contracts;
using pdfConverter.WPF.ViewModels;

namespace simplePdfConverter.WPF.Modules
{
    public class Navigator : INavigator
    {
        IWindowManager manager = new WindowManager();
        public Navigator()
        {
        }

        public void ShowDialog(string title, string text)
        {
            var dialog = new DialogViewModel(title, text);
            this.manager.ShowDialogAsync(dialog);
        }
    }
}