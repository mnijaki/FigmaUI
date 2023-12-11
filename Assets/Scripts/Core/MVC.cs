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
        public TContext Context { get; protected set; }
        public TModel Model { get; protected set; }
        public TView View  { get; protected set; }
        public TController Controller  { get; protected set; }
        public TService Service  { get; protected set; }
        public bool IsInitialized  { get; protected set; }
        
        public virtual void Initialize()
        {
            throw new Exception("MustOverrideMethod");
        }

        public virtual void Dispose()
        {
            IsInitialized = false;
            Context.Dispose();
        }
    }
}