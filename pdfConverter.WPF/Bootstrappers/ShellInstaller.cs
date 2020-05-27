using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using pdfConverter.WPF.ViewModels;
using simplePdfConverter.Contracts.Bootstrappers;
using simplePdfConverter.Database.Services;
using simplePdfConverter.WPF.Bootstrappers;
using simplePdfConverter.WPF.Modules;

namespace pdfConverter.WPF.Bootstrappers
{
    public class ShellInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var mapper = Automapper.Init();

            container
                .Register(Component.For<IWindsorContainer>().Instance(container))
                .Register(Component.For<ModuleLoader>())
                .Register(Component.For<MainViewModel>())
                .Register(Component.For<SettingsViewModel>())
                .Register(Component.For<IModule>().ImplementedBy<BaseModule>())
                .Register(Component.For<IShell>().ImplementedBy<BaseShell>())
                .Register(Component.For<ShellViewModel>() /*.LifeStyle.Singleton*/)

                .Register(Component.For<IMapper>().Instance(mapper))
                .Register(Component.For<INavigator>().ImplementedBy<Navigator>())
                .Register(Component.For<IDbAccess>().ImplementedBy<DbAccess>());
        }
    }
}
