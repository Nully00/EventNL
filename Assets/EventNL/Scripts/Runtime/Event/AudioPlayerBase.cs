using System;
using System.Collections.Generic;
using UnityEngine;


namespace NL.Event
{
    public abstract class AudioPlayerBase : MonoBehaviour
    {

        [SerializeField]
        protected AudioSource audioSource;
        [SerializeField]
        private List<AudioClipPack> _clipPacks;
        private Dictionary<string, AudioClip> _audioDictionary = new Dictionary<string, AudioClip>();

        private void Awake()
        {
            foreach (var clipPack in _clipPacks)
            {
                foreach (var element in clipPack.elements)
                {
                    string clipName = (element.name == "") ? element.audioClip.name : element.name;
                    _audioDictionary.Add(clipName, element.audioClip);
                }
            }
        }
        public AudioClip GetAudioClip(string bgmName)
        {
            if (!_audioDictionary.TryGetValue(bgmName, out var clip))
                throw new ArgumentException($"{bgmName}は登録されていません。");

            return clip;
        }
    }
}
