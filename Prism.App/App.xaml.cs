using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Splash;
using Splash.Events;
using System.Windows;

namespace PrismSplash
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MainWindow.Activate();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }

        protected override void InitializeModules()
        {
            IModuleManager moduleManager = Container.Resolve<IModuleManager>();
            moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;

            IModule splashModule = Container.Resolve<SplashModule>();
            splashModule.OnInitialized(Container);

            base.InitializeModules();

            //IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();

            //eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleA" });
            //IModule customersModule = Container.Resolve<ModuleAModule>();
            //customersModule.OnInitialized(Container);

            //eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleB" });
            //IModule locationModule = Container.Resolve<ModuleBModule>();
            //locationModule.OnInitialized(Container);

            //eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleC" });
            //IModule ordersModule = Container.Resolve<ModuleCModule>();
            //ordersModule.OnInitialized(Container);
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<MessageUpdateSplashEvent>().Publish(new MessageUpdateSplashEvent { Message = $"{e.ModuleInfo.ModuleName} - {e.ModuleInfo.State}" });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
