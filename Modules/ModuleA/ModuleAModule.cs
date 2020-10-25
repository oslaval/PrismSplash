using Prism.Ioc;
using Prism.Modularity;
using System.Threading;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Thread.Sleep(2000);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}