using Prism.Events;

namespace Splash.Events
{
  public class MessageUpdateEvent : PubSubEvent<MessageUpdateEvent>
    {
    public string Message { get; set; }
  }
}
