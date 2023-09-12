using System.Collections.Generic;
using UnityEngine;

namespace NL.Event
{
    [CreateAssetMenu(menuName = "AudioClipPack", fileName = "AutioClipPack")]
    public class AudioClipPack : ScriptableObject
    {
        public List<AudioClipPackElement> elements;

        [System.Serializable]
        public class AudioClipPackElement
        {
            public string name;
            public AudioClip audioClip;
        }
    }
}
