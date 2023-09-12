using System.Collections.Generic;
using UnityEngine;
namespace NL.Event
{
    public class ChangeAutioSourceVolume : GameEventListenerBase<float>
    {
        [SerializeField]
        private FloatGameEvent _onChangeVolume;
        [SerializeField]
        private List<AudioSource> _audioSources;

        public override void OnEventRaised(float value)
        {
            base.OnEventRaised(value);
            foreach (var audioSource in _audioSources)
            {
                audioSource.volume = value;
            }
        }

        protected override GameEventBase<float> GetEvent()
        {
            return _onChangeVolume;
        }
    }
}
