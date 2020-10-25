using Prism.Ioc;
using Prism.Modularity;
using System.Threading;

namespace ModuleC
{
    public class ModuleCModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Thread.Sleep(1000);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}