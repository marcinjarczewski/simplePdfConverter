using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using pdfConverter.Contracts;
using pdfConverter.WPF.Bootstrappers;
using pdfConverter.WPF.ViewModels;
using simplePdfConverter.Contracts;
using simplePdfConverter.Contracts.Bootstrappers;
using System.Collections.Generic;
using System.Reflection;

namespace simplePdfConverter.WPF.Bootstrappers
{
    public class BaseShell : IShell
    {
        private readonly ModuleLoader _loader;
        private readonly ShellViewModel _shellViewModel;

        public BaseShell(ModuleLoader loader, ShellViewModel shellViewModel)
        {
            _loader = loader;
            _shellViewModel = shellViewModel;
        }

        public IList<ShellMenuItem> MenuItems { get { return _shellViewModel.MenuItems; } }

        public IModule LoadModule(Assembly assembly)
        {
            return _loader.LoadModule(assembly);
        }
    }
}