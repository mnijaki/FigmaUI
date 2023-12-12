namespace MN.Runtime.UI.BottomBar.View
{
	using System.Collections.Generic;
	using System.Linq;
	using Core.Ctx;
	using Core.View;
	using UnityEngine;

	public class BottomBarView : MonoBehaviour, IView
	{
		public List<BottomBarButtonView> Buttons { get; private set; }
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }

		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
            
			Context = context;

			Buttons = GetComponentsInChildren<BottomBarButtonView>().ToList();
            
			// MN:TODO: set initial state of buttons (which one should be selected).
            
			IsInitialized = true;
		}
	}
}