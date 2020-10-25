using Prism.Events;
using Prism.Mvvm;
using Splash.Events;
using System;

namespace Splash.ViewModels
{
    public class SplashViewModel : BindableBase
    {
        #region Declarations
        private string _status;
        #endregion

        #region ctor
        public SplashViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageUpdateSplashEvent>().Subscribe(e => UpdateMessage(e.Message));
        }
        #endregion

        #region Public Properties
        public string Status
        {
            get { return _status; }
            set
            {
                SetProperty(ref _status, value);
            }
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
