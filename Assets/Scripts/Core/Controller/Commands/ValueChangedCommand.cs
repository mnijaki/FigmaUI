namespace MN.Core.Controller.Commands
{
	/// <summary>
	///   This Command is a stand-alone object containing the before and after value during a data change.
	/// </summary>
	public abstract class ValueChangedCommand<TValue> : ICommand
	{
		public TValue PreviousValue { get; }
		public TValue CurrentValue { get; }

		public ValueChangedCommand(TValue previousValue, TValue currentValue)
		{
			PreviousValue = previousValue;
			CurrentValue = currentValue;
		}
	}
}