using System;
using System.Collections.Generic;
using UnityEngine;
namespace NL.Event
{
    public abstract class GameEventBase<T> : ScriptableObject
    {
        public bool outputLog = false;
        private List<GameEventListenerBase<T>> _listeners = new List<GameEventListenerBase<T>>();
        private List<Action<T>> _actions = new List<Action<T>>();
        public void Raise(T value)
        {
            if (outputLog)
                Debug.Log($"Event {name} raised.");


            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
            for (int i = 0; i < _actions.Count; i++)
            {
                _actions[i]?.Invoke(value);
            }
        }
        public IDisposable RegisterAction(Action<T> action)
        {
            _actions.Add(action);
            return new DisposableAction(this, action);
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
        private void UnregisterAction(Action<T> action)
        {
            _actions.Remove(action);
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
        private class DisposableAction : IDisposable
        {
            private readonly GameEventBase<T> EventInstance;
            private readonly Action<T> ActionInstance;

            public DisposableAction(GameEventBase<T> eventInstance, Action<T> actionInstance)
            {
                EventInstance = eventInstance;
                ActionInstance = actionInstance;
            }

            public void Dispose()
            {
                EventInstance.UnregisterAction(ActionInstance);
            }
        }
    }
}