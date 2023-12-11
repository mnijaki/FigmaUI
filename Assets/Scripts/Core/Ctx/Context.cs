namespace MN.Core.Ctx
{
	using Controller.Commands;

	/// <summary>
	/// The <see cref="IMVC"/>
	/// shares one <see cref="Context"/> instance with each of its <see cref="IConcern"/>s so they can co-relate.
	/// The context provides object lookup functionality through the <see cref="ModelLocator"/> and communication functionality via <see cref="CommandManager"/>.
	///
	/// <p>Advanced Use Case</p>
	/// 
	/// Two or more <see cref="IMVC"/> instances which share one <see cref="Context"/> instance can co-relate.
	/// 
	/// </summary>
	public class Context : IContext
	{
		public ICommandManager CommandManager { get; }
		public ModelLocator ModelLocator { get; }

		public Context()
		{
			ModelLocator = new ModelLocator();
			CommandManager = new CommandManager();
		}
		   
		public virtual void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}