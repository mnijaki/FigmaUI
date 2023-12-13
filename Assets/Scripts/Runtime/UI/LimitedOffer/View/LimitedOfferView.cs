namespace MN.Runtime.UI.LimitedOffer.View
{
	using Controller;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UnityEngine;

	// MN:TODO: Split timer into two canvases so it will not dirty the whole UI.
	public class LimitedOfferView : MonoBehaviour, IView
	{
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }

		[SerializeField]
		private TMP_Text _timerTxt;

		private Timer _timer;

		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
            
			Context = context;
			
			_timer= new Timer();
            
			IsInitialized = true;
		}

		private void Update()
		{
			_timer.Tick(Time.deltaTime);
			_timerTxt.text = _timer.TimeLeftTxt;
		}
	}
}