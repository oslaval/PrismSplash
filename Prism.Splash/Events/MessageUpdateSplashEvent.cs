using Prism.Events;

namespace Splash.Events
{
    public class MessageUpdateSplashEvent : PubSubEvent<MessageUpdateSplashEvent>
    {
        public string Message { get; set; }
    }
}
