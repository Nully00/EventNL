using UnityEngine;

namespace NL.Event
{
    [CreateAssetMenu(menuName = "ScriptableGameEvent/GameEvent", fileName = "Event")]
    public class GameEvent : GameEventBase<Void>
    {
        public void Raise()
        {
            base.Raise(Void.Instance);
        }
    }
}