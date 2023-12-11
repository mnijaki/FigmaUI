namespace MN.Core.Service
{
    using Ctx;

    /// <summary>
    ///  The Service handles external data, 
    /// </summary>
    public abstract class BaseService : IService
    {
        public bool IsInitialized { get; private set; }
        public IContext Context { get; private set; }

        public virtual void Initialize(IContext context)
        {
            if(IsInitialized)
            {
                return;
            }
            
            IsInitialized = true;
            Context = context;
        }
    }
}