using System;
using MN.Core.Controller.Commands;

namespace MN.Core.Context
{
	/// <summary>
	/// The <see cref="IMiniMvcs"/>
	/// shares one <see cref="Context"/> instance with each of its <see cref="IConcern"/>s so they can co-relate.
	/// The context provides object lookup functionality through the <see cref="ModelLocator"/> and communication functionality via <see cref="CommandManager"/>.
	///
	/// <p>Advanced Use Case</p>
	/// 
	/// Two or more <see cref="IMiniMvcs"/> instances which share one <see cref="Context"/> instance can co-relate.
	/// 
	/// </summary>
	public class Context : BaseContext
	{
		protected readonly string _contextKey;

		public Context(string contextKey = "") : base()
		{
			_contextKey = contextKey;
			if (string.IsNullOrEmpty(_contextKey))
			{
				_contextKey = Guid.NewGuid().ToString();
			}
			
			// ContextLocator is Experimental.
			// This allows any scope, including non-mini classes, to access any Context via ContextLocator.Instance.GetItem<T>();
			if (ContextLocator.Instance.HasItem<Context>(_contextKey))
			{
				throw new Exception($"Context with key '{_contextKey}' already exists. Must pass in unique contextKey.");
			}
			
			ContextLocator.Instance.AddItem(this, _contextKey);
		}
		
		public override void Dispose()
		{
			if (ContextLocator.Instance.HasItem<Context>(_contextKey))
			{
				ContextLocator.Instance.RemoveItem<Context>(_contextKey);
			}
		}
	}
}