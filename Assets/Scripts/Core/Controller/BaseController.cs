namespace MN.Core.Controller
{
    using Ctx;
    
    /// <summary>
    ///   The Controller coordinates everything between the <see cref="IConcern"/>s and contains the core app logic.
    /// </summary>
    public abstract class BaseController<TModel,TView,TService> : BaseController<TModel, TView>
    {
        protected readonly TService _service;

        protected BaseController(TModel model, TView view, TService service) : base(model, view)
        {
            _service = service;
        }
    }
    
    public abstract class BaseController<TModel,TView> : BaseController<TView>
    {
        protected readonly TModel _model;

        protected BaseController(TModel model, TView view) : base(view)
        {
            _model = model;
        }
    }
    
    public abstract class BaseController<TView> : IController
    {
        public bool IsInitialized { get; protected set; }
        public IContext Context { get; protected set; }

        protected readonly TView _view;

        protected BaseController(TView view)
        {
            _view = view;
        }

        public abstract void Initialize(IContext context);
    }
}