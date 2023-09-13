using System;
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
        public IDisposable RegisterAction(Action action)
        {
            Action<Void> voidAction = (Void) => action?.Invoke();
            return base.RegisterAction(voidAction);
        }
    }
}