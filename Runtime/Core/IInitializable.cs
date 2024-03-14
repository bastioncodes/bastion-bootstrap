namespace SebastianFeistl.Winky.Core
{
    public interface IInitializable
    {
        bool IsInitialized { get; }
        void Initialize();
    }
}