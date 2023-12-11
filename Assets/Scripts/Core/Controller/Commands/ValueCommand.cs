namespace MN.Core.Controller.Commands
{
	/// <summary>
	///   This Command is a stand-alone object containing a Value of Data.
	/// </summary>
	public abstract class ValueCommand<TValue> : ICommand
	{
		public TValue Value { get; }

		public ValueCommand(TValue value)
		{
			Value = value;
		}
	}
}