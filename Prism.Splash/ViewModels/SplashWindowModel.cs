using Prism.Events;
using Prism.Mvvm;
using Splash.Events;
using System;
using System.Reflection;
using System.Windows;

namespace Splash.ViewModels
{
    public class SplashWindowModel : BindableBase
    {
        #region Declarations
        private string _status;
        #endregion

        #region ctor
        public SplashWindowModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageUpdateSplashEvent>().Subscribe(e => UpdateMessage(e.Message));
        }
        #endregion

        #region Public Properties
        public string Title { get; } = $"{Application.ResourceAssembly.GetName().Name} {Application.ResourceAssembly.GetName().Version}";

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        #endregion

        #region Private Methods
        private void UpdateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            Status += string.Concat(Environment.NewLine, message, "...");
        }
        #endregion
    }
}
