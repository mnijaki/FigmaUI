namespace MN.Core.Service
{
    using Ctx;

    /// <summary>
    ///   The Service handles external data.
    /// </summary>
    public interface IService : IConcern
    {
        public void Initialize(IContext context);
    }
}