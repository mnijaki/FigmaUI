namespace MN.Core.Ctx
{
	using UnityEngine.Events;

	/// <summary>
	///   The <see cref="UnityEvent"/> for <see cref="Observable{T}"/>.
	/// </summary>
	public class ObservableUnityEvent<T, U> : UnityEvent<T, U>
	{
		private readonly Observable<T> _observable;
        
		public ObservableUnityEvent(Observable<T> observable)
		{
			_observable = observable;
		}

		/// <summary>
		///   Consuming scope can optionally 'catch up' to the existing value by immediately refreshing value to the observer.
		/// </summary>
		/// <param name="call"></param>
		/// <param name="refreshImmediately"></param>
		public void AddListener(UnityAction<T, U> call, bool refreshImmediately = false)
		{
			base.AddListener(call);
            
			if(refreshImmediately)
			{
				_observable.RefreshOnValueChanged();
			}
		}
	}
}