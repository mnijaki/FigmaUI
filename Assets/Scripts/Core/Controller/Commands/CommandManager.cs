using System.Collections.Generic;

namespace MN.Core.Controller.Commands
{
	/// <summary>
	///   The CommandManager allows to observe and invoke <see cref="ICommand"/> instances.
	/// Summary
	///		* Call AddCommandListener() to observe a command.
	///		* Call Invoke(). This executes nothing, but notifies any listeners.
	/// </summary>
	public class CommandManager : ICommandManager
	{
		public delegate void InvokeCommandDelegate<TCommand>(TCommand command) where TCommand : ICommand;
		private delegate void InvokeCommandDelegate(ICommand command);
		private readonly Dictionary<System.Type, InvokeCommandDelegate> _invokeCommandDelegates = new();
		private readonly Dictionary<System.Delegate, InvokeCommandDelegate> _invokeCommandDelegatesLookup = new();

		public void InvokeCommand(ICommand command)
		{
			InvokeCommandDelegate del;
			if (_invokeCommandDelegates.TryGetValue(command.GetType(), out del))
			{
				// Call the HANDLER and pass the COMMAND.
				del.Invoke(command);
			}
		}
		
		public void AddCommandListener<TCommand>(InvokeCommandDelegate<TCommand> invokeDelegate) where TCommand : ICommand
		{
			if (_invokeCommandDelegatesLookup.ContainsKey(invokeDelegate))
			{
				return;
			}

			InvokeCommandDelegate internalDelegate = (e) => invokeDelegate((TCommand)e);
			_invokeCommandDelegatesLookup[invokeDelegate] = internalDelegate;

			if (_invokeCommandDelegates.TryGetValue(typeof(TCommand), out InvokeCommandDelegate tempDel))
			{
				_invokeCommandDelegates[typeof(TCommand)] = tempDel += internalDelegate;
			}
			else
			{
				_invokeCommandDelegates[typeof(TCommand)] = internalDelegate;
			}
		}
		
		public void RemoveCommandListener<TCommand>(InvokeCommandDelegate<TCommand> del) where TCommand : ICommand
		{
			if (_invokeCommandDelegatesLookup.TryGetValue(del, out InvokeCommandDelegate internalDelegate))
			{
				if (_invokeCommandDelegates.TryGetValue(typeof(TCommand), out InvokeCommandDelegate tempDel))
				{
					tempDel -= internalDelegate;
					if (tempDel == null)
					{
						_invokeCommandDelegates.Remove(typeof(TCommand));
					}
					else
					{
						_invokeCommandDelegates[typeof(TCommand)] = tempDel;
					}
				}

				_invokeCommandDelegatesLookup.Remove(del);
			}
		}
	}
}