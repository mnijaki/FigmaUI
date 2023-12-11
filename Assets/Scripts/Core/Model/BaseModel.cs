namespace MN.Core.Model
{
    using Ctx;

    /// <summary>
    ///   The Model stores runtime data. 
    /// </summary>
    public abstract class BaseModel: IModel
    {
        public bool IsInitialized { get; private set; }
        public IContext Context { get; private set; }

        public virtual void Initialize(IContext context, string key = "")
        {
            if(IsInitialized)
            {
                return;
            }
            
            IsInitialized = true;
            Context = context;
                
            Context.ModelLocator.AddItem(this, key);
        }
    }
}