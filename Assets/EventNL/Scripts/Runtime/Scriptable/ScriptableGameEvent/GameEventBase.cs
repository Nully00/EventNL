using System;
using System.Collections.Generic;
using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventBase<T> : ScriptableObject
    {
        public bool outputLog = false;
        private List<GameEventListenerBase<T>> _listeners = new List<GameEventListenerBase<T>>();
        public void Raise(T value)
        {
            if (outputLog)
                Debug.Log($"Event {name} raised.");


            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }

        public IDisposable RegisterListener(GameEventListenerBase<T> listener)
        {
            _listeners.Add(listener);
            return new Disposable(this, listener);
        }

        public void UnregisterListener(GameEventListenerBase<T> listener)
        {
            _listeners.Remove(listener);
        }
        private class Disposable : IDisposable
        {
            private readonly GameEventBase<T> EventInstance;
            private readonly GameEventListenerBase<T> ListenerInstance;

            public Disposable(GameEventBase<T> eventInstance, GameEventListenerBase<T> listenerInstance)
            {
                EventInstance = eventInstance;
                ListenerInstance = listenerInstance;
            }

            public void Dispose()
            {
                EventInstance.UnregisterListener(ListenerInstance);
            }
        }
    }
}