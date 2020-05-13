using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using pdfConverter.Contracts;
using pdfConverter.WPF.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace pdfConverter.WPF.Bootstrappers
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
            _shell.MenuItems.Add(new ShellMenuItem() { Caption = "First", ScreenViewModel = _mainViewModel });
            _shell.MenuItems.Add(new ShellMenuItem() { Caption = "Second", ScreenViewModel = _settingsViewModel });
        }
    }
}