namespace MN.Core.View
{
    using Ctx;

    /// <summary>
    ///   The View handles user interface and user input.
    /// </summary>
    public interface IView : IConcern
    {
        public void Initialize(IContext context);
    }
}