namespace Bastion.Core
{
    public interface IInitializable
    {
        bool IsInitialized { get; }
        void Initialize();
    }
}