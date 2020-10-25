using ModuleA;
using ModuleB;
using ModuleC;
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

        protected override void InitializeModules()
        {
            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();

            IModule splashModule = Container.Resolve<SplashModule>();
            splashModule.OnInitialized(Container);

            eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleA" });
            IModule customersModule = Container.Resolve<ModuleAModule>();
            customersModule.OnInitialized(Container);

            eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleB" });
            IModule locationModule = Container.Resolve<ModuleBModule>();
            locationModule.OnInitialized(Container);

            eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "ModuleC" });
            IModule ordersModule = Container.Resolve<ModuleCModule>();
            ordersModule.OnInitialized(Container);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
