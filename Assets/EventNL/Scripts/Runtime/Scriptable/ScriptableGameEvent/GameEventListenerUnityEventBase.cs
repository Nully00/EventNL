using UnityEngine.Events;
using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventListenerUnityEventBase<T> : GameEventListenerBase<T>
    {
        [SerializeField]
        protected GameEventBase<T> @event;
        [SerializeField]
        protected UnityEvent<T> response;
        public override void OnEventRaised(T value)
        {
            base.OnEventRaised(value);
            response.Invoke(value);
        }
        protected override GameEventBase<T> GetEvent()
        {
            return @event;
        }
    }
}