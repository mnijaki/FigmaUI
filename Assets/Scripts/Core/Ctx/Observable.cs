namespace MN.Core.Ctx
{
	/// <summary>
	///   Wrapper where any changes to value of type
	/// <see cref="TValue"/> can be observable via events
	/// </summary>
	public class Observable<TValue> 
	{
		public readonly ObservableUnityEvent<TValue, TValue> OnValueChanged;

		/// <summary>
		///   Keep this property name as "Value" !!!
		/// </summary>
		public TValue Value
		{
			set
			{
				_currentValue = OnValueChanging(_currentValue, value);
				OnValueChanged.Invoke(_previousValue, _currentValue);
			}
			get
			{
				return _currentValue;
			}
		}

		private TValue _currentValue;
		private TValue _previousValue;

		public Observable()
		{
			OnValueChanged = new ObservableUnityEvent<TValue,TValue>(this);
		}

		/// <summary>
		///   Refresh the observers by recalling Invoke() with the latest values.
		/// </summary>
		public void RefreshOnValueChanged()
		{
			OnValueChanged.Invoke(_previousValue, _currentValue);
		}
        
		private TValue OnValueChanging(TValue previousValue, TValue newValue)
		{
			_previousValue = previousValue;
            
			return newValue;
		}
	}
}