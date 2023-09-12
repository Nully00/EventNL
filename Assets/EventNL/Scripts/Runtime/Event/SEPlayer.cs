using UnityEngine;

namespace NL.Event
{
    public class SEPlayer : AudioPlayerBase, ISEPlayer
    {
        [Tooltip("volumeを指定したとき用のAudioSource")]
        [SerializeField]
        private AudioSource _audioSource2;
        public void Play(string bgmName)
        {
            audioSource.PlayOneShot(GetAudioClip(bgmName));
        }

        public void Play(string bgmName, float volume)
        {
            _audioSource2.PlayOneShot(GetAudioClip(bgmName), audioSource.volume * volume);
        }
    }
}
