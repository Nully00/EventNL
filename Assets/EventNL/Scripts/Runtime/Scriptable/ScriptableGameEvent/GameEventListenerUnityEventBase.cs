using UnityEngine.Events;
using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventListenerUnityEventBase<T> : GameEventListenerBase<T>
    {
        [SerializeField]
        protected UnityEvent<T> response;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {

            @event.UnregisterListener(this);
        }

        public override void OnEventRaised(T value)
        {
            base.OnEventRaised(value);
            response.Invoke(value);
        }
    }
}