namespace MN.Core.Ctx
{
    /// <summary>
    ///   Enforces API for types that can be Initialize with Context parameter.
    /// </summary>
    public interface IInitializableWithContext
    {
        public bool IsInitialized { get; }
        public IContext Context { get; }
    }
}