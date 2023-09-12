using UnityEngine.Events;
namespace NL.Event
{
    public class GameEventListener : GameEventListenerUnityEventBase<Void>
    {
        public override void OnEventRaised(Void item)
        {
            response.Invoke(item);
        }
    }
}