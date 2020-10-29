using Prism.Ioc;
using Prism.Modularity;
using System.Threading;

namespace ModuleB
{
    public class ModuleB : IModule
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