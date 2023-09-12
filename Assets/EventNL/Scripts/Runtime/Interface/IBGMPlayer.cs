namespace NL.Event
{
    public interface IBGMPlayer
    {
        void Play(string bgmName, bool looping = true);
        void Stop();
    }
}