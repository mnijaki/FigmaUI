using System;
using MN.Core.Context;
using MN.Core.Controller;
using MN.Core.Model;
using MN.Core.Service;
using MN.Core.View;

namespace MN.Core
{
    /// <summary>
    ///   The MiniMvcs is the parent object containing all <see cref="IConcern"/>s as children.
    /// </summary>
    public class MiniMvcs<TContext, TModel, TView, TController, TService> : IMiniMvcs, IDisposable
        where TContext : IContext 
        where TModel : IModel 
        where TView : IView
        where TController : IController 
        where TService : IService 
    
    {
        public TContext Context { get { return _context;} }
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