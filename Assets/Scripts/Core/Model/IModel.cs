
namespace MN.Core.Model
{
    using Ctx;

    /// <summary>
    ///   The Model stores runtime data.
    /// </summary>
    public interface IModel : IConcern
    {
        public void Initialize(IContext context, string key = "");
    }
}