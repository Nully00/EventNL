namespace NL.Event
{
    public class BGMPlayer : AudioPlayerBase, IBGMPlayer
    {
        public void Play(string bgmName, bool looping = true)
        {
            audioSource.loop = looping;
            audioSource.clip = GetAudioClip(bgmName);
            audioSource.Play();
        }

        public void Stop()
        {
            audioSource.Stop();
        }
    }
}

