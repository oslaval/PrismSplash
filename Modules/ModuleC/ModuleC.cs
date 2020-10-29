using Prism.Ioc;
using Prism.Modularity;
using System.Threading;

namespace ModuleC
{
    public class ModuleC : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Thread.Sleep(500);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}