namespace NL.Event
{
    interface IBGMPlayer
    {
        void Play(string bgmName, bool looping = true);
        void Stop();
    }
}