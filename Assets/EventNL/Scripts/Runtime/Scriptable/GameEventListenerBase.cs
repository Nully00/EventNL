using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventListenerBase<T> : MonoBehaviour
    {
        [SerializeField]
        protected GameEventBase<T> @event;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {

            @event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T value) 
        {
            if (@event.outputLog)
            {
                Debug.Log($"Listener '{gameObject.name}' in scene '{gameObject.scene.name}' with Instance ID {GetInstanceID()} responded to event {@event.name}.");
            }
        }
    }
}