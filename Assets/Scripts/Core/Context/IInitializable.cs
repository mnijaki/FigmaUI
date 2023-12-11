namespace MN.Core.Context
{
    public interface IInitializable
    {
        public bool IsInitialized { get; }

        public void Initialize();
    }
}