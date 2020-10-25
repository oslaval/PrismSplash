# PrismSplash
- using prism 8

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
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            IEventAggregator eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<MessageUpdateSplashEvent>().Publish(new MessageUpdateSplashEvent { Message = $"{e.ModuleInfo.ModuleName} - {e.ModuleInfo.State}" });
        }


- splash module

        public void OnInitialized(IContainerProvider containerProvider)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                EventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
            });

            WaitForCreation = new AutoResetEvent(false);

            ThreadStart showSplash = () =>
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(() =>
                {
                    SplashView splash = containerProvider.Resolve<SplashView>();

                    EventAggregator.GetEvent<CloseSplashEvent>().Subscribe(e =>
                    {
                        Thread.Sleep(500);
                        splash.Dispatcher.BeginInvoke(splash.Close);

                    }, ThreadOption.PublisherThread, true);                 

                    splash.Show();

                    WaitForCreation.Set();
                });

                Dispatcher.Run();
            };

            Thread thread = new Thread(showSplash) { Name = "Splash Thread", IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            WaitForCreation.WaitOne();
        }
