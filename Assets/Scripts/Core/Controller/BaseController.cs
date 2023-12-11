namespace MN.Core.Controller
{
    using Ctx;
    
    /// <summary>
    ///   The Controller coordinates everything between the <see cref="IConcern"/>s and contains the core app logic.
    /// </summary>
    public abstract class BaseController<TModel,TView,TService>: IController
    {
        public bool IsInitialized { get; private set; }
        public IContext Context { get; private set; }

        protected readonly TModel _model;
        protected readonly TView _view;
        protected readonly TService _service;

        public BaseController(TModel model, TView view, TService service)
        {
            _model = model;
            _view = view;
            _service = service;
        }

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