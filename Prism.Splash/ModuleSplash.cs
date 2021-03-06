﻿using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Splash.Events;
using Splash.Views;
using System.Threading;
using System.Windows.Threading;

namespace Splash
{
    public class ModuleSplash : IModule
    {        
        #region Private Properties
        private IEventAggregator EventAggregator { get; set; }

        private AutoResetEvent WaitForCreation { get; set; }
        #endregion

        public ModuleSplash(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                EventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
            });

            WaitForCreation = new AutoResetEvent(false);

            void showSplash()
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                {
                    SplashWindow splash = containerProvider.Resolve<SplashWindow>();

                    EventAggregator.GetEvent<CloseSplashEvent>().Subscribe(e =>
                    {
                        Thread.Sleep(500);
                        splash.Dispatcher.BeginInvoke(splash.Close);

                    }, ThreadOption.PublisherThread, true);

                    splash.Show();

                    WaitForCreation.Set();
                });

                Dispatcher.Run();
            }

            Thread thread = new Thread(showSplash) { Name = "Splash Thread", IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            WaitForCreation.WaitOne();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}