namespace MN.Core
{
    /// <summary>
    ///   Enforces API for types that can be Initialize.
    /// </summary>
    public interface IInitializable
    {
        public bool IsInitialized { get; }

        public void Initialize();
    }
}