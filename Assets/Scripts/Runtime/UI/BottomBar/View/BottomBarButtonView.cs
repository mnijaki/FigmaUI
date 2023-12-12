namespace MN.Runtime.UI.BottomBar.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using UnityEngine;

	public class BottomBarButtonView : MonoBehaviour, IView
	{
		public event Action<BottomBarButtonView> OnClicked;
		
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }
		
		[SerializeField]
		private BottomBarButtonTheme _selectedTheme;
		[SerializeField]
		private BottomBarButtonTheme _unselectedTheme;
		[SerializeField]
		private BottomBarButtonTheme _hoveredTheme;
		[SerializeField]
		private BottomBarButtonProperties _properties;
		
		private bool _isSelected;
		
		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;

			Unselect();
			SubscribeToPointerEvents();
				
			IsInitialized = true;
		}

		public void Unselect()
		{
			_properties.DownloadNowGO.SetActive(false);
			_properties.GetDataGO.SetActive(false);
			_properties.SetTheme(_unselectedTheme);
			_isSelected = false;
		}

		public void Select()
		{
			_properties.DownloadNowGO.SetActive(true);
			_properties.GetDataGO.SetActive(true);
			_properties.SetTheme(_selectedTheme);
			_isSelected = true;
		}
		
		private void SubscribeToPointerEvents()
		{
			UIPointerHandler pointerHandler = GetComponentInChildren<UIPointerHandler>();
			pointerHandler.OnPointerClicked += OnPointerClicked;
			pointerHandler.OnPointerEntered += OnPointerEntered;
			pointerHandler.OnPointerExited += OnPointerExited;
		}

		private void OnPointerClicked(UIPointerHandler pointerHandler)
		{
			// MN:TODO: animations, sounds, etc...
			OnClicked?.Invoke(this);
			
			Select();
		}

		private void OnPointerEntered(UIPointerHandler pointerHandler)
		{
			if(_isSelected)
			{
				return;
			}
			
			_properties.SetTheme(_hoveredTheme);
		}
		
		private void OnPointerExited(UIPointerHandler pointerHandler)
		{
			_properties.SetTheme(_isSelected ? _selectedTheme : _unselectedTheme);
		}
	}
}