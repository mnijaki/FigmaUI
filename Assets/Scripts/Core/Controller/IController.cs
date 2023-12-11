namespace MN.Core.Controller
{
    using Ctx;

    /// <summary>
    /// The Controller coordinates everything between
    /// the <see cref="IConcern"/>s and contains the core app logic 
    /// </summary>
    public interface IController : IConcern
    {
        public void Initialize(IContext context);
    }
}