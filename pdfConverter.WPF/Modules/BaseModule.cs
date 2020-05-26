using pdfConverter.Contracts;
using pdfConverter.WPF.ViewModels;
using simplePdfConverter.Contracts;
using simplePdfConverter.Contracts.Bootstrappers;

namespace simplePdfConverter.WPF.Modules
{
    public class BaseModule : IModule
    {
        private readonly IShell _shell;
        private readonly MainViewModel _mainViewModel;
        private readonly SettingsViewModel _settingsViewModel;

        public BaseModule(IShell shell, MainViewModel mainViewModel, SettingsViewModel settingsViewModel)
        {
            _shell = shell;
            _mainViewModel = mainViewModel;
            _settingsViewModel = settingsViewModel;
        }

        public void Init()
        {
            _shell.MenuItems.Add(new ShellMenuItem() { Caption = "Convert", ScreenViewModel = _mainViewModel });
            _shell.MenuItems.Add(new ShellMenuItem() { Caption = "Settings", ScreenViewModel = _settingsViewModel });
        }
    }
}