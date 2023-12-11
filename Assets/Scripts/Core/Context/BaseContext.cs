using MN.Core.Controller.Commands;

namespace MN.Core.Context
{
	public class BaseContext : IContext
	{
		public ICommandManager CommandManager { get; }
		public ModelLocator ModelLocator { get; }

		protected BaseContext()
		{
			ModelLocator = new ModelLocator();
			CommandManager = new CommandManager(this);
		}
		   
		public virtual void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}