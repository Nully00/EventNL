namespace NL.Event
{
    public struct Void
    {
        private static readonly Void ReadOnlyInstance = new Void();
        public static Void Instance => ReadOnlyInstance;
    }
}