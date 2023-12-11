namespace MN.Core
{
    using System;
    using Controller;
    using Ctx;
    using View;
    using Model;
    using Service;

    /// <summary>
    ///   The MVC is the parent object containing all <see cref="IConcern"/>s as children.
    /// </summary>
    public class MVC<TContext, TModel, TView, TController, TService> : IMVC, IDisposable
        where TContext : IContext 
        where TModel : IModel 
        where TView : IView
        where TController : IController 
        where TService : IService 
    
    {
        public TContext ccontext { get { return _context;} }
        public TModel Model { get { return _model;} }
        public TView View { get { return _view;} }
        public TController Controller { get; }protected TContext _context;
        public TService Service { get { return _service;} }
        public bool IsInitialized { get { return _isInitialized;} }
        
        protected TController _controller;
        protected bool _isInitialized = false;
        protected TModel _model;
        protected TService _service;
        protected TView _view;
        
        public virtual void Initialize()
        {
            throw new Exception("MustOverrideMethod");
        }

        public virtual void Dispose()
        {
            _isInitialized = false;
            _context.Dispose();
        }
  
    }
}