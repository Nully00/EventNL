using UnityEngine.Events;
namespace NL.Event
{
    public class GameEventListener : GameEventListenerBase<Void>
    {
        public override void OnEventRaised(Void item)
        {
            response.Invoke(item);
        }
    }
}