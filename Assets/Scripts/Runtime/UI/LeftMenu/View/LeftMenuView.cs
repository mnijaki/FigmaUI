namespace MN.Runtime.UI.LeftMenu.View
{
	using System.Collections.Generic;
	using System.Linq;
	using Core.Ctx;
	using Core.View;
	using UnityEngine;

	public class LeftMenuView : MonoBehaviour, IView
	{
		public List<LeftMenuButtonView> Buttons { get; private set; }
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }

		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
            
			Context = context;

			Buttons = GetComponentsInChildren<LeftMenuButtonView>().ToList();
            
			// MN:TODO: set initial state of buttons (which one should be selected).
            
			IsInitialized = true;
		}
	}
}