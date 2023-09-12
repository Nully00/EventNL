using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventListenerBase<T> : MonoBehaviour
    {        
        private void OnEnable()
        {
            GetEvent().RegisterListener(this);
        }

        private void OnDisable()
        {

            GetEvent().UnregisterListener(this);
        }
        protected abstract GameEventBase<T> GetEvent();
        public virtual void OnEventRaised(T value) 
        {
            if (GetEvent().outputLog)
            {
                Debug.Log($"Listener '{gameObject.name}' in scene '{gameObject.scene.name}' with Instance ID {GetInstanceID()} responded to event {GetEvent().name}.");
            }
        }
    }
}