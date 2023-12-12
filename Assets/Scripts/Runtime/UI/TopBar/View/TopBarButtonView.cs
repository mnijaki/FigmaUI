namespace MN.Runtime.TopBar.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UI;
	using UnityEngine;
	using UnityEngine.Serialization;
	using UnityEngine.UI;

	public class TopBarButtonView : MonoBehaviour, IView
	{
		public event Action<TopBarButtonView> OnClicked;
		
		public bool IsInitialized { get; private set; }
		
		public IContext Context { get; private set; }
		
		
		[SerializeField] 
		private Color _selectedColor;
		
		[SerializeField] 
		private Color _unselectedColor;
		
		[FormerlySerializedAs("_hoverColor")]
		[SerializeField] 
		private Color _hoveredColor;
		
		[SerializeField]
		private Image _buttonIcon;

		[SerializeField]
		private Image _diamondIcon;

		[SerializeField]
		private TMP_Text _txt;

		
		private bool _isSelected;
		private Color _previousButtonIconColor;
		private Color _previousDiamondIconColor;
		private Color _previousTxtColor;
		
		
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
			SetButtonState(UIButtonState.Unselected);
		}

		private void Select()
		{
			SetButtonState(UIButtonState.Selected);
		}
		
		private void SubscribeToPointerEvents()
		{
			UIPointerHandler pointerHandler = GetComponentInChildren<UIPointerHandler>();
			pointerHandler.OnPointerClicked += OnPointerClick;
			pointerHandler.OnPointerEntered += OnPointerEnter;
			pointerHandler.OnPointerExited += OnPointerExit;
		}

		private void OnPointerClick(UIPointerHandler pointerHandler)
		{
			// MN:TODO: animations, sounds, etc...
			OnClicked?.Invoke(this);
			
			Select();
		}

		private void OnPointerEnter(UIPointerHandler pointerHandler)
		{
			if(_isSelected)
			{
				return;
			}
			
			CacheButtonProperties();
			SetButtonState(UIButtonState.Hovered);
		}
		
		private void OnPointerExit(UIPointerHandler pointerHandler)
		{
			if(_isSelected)
			{
				return;
			}
			
			RestoreButtonProperties();
		}

		private void CacheButtonProperties()
		{
			_previousButtonIconColor = _buttonIcon.color;
			_previousDiamondIconColor = _diamondIcon.color;
			_previousTxtColor = _txt.color;
		}
		
		private void RestoreButtonProperties()
		{
			_buttonIcon.color = _previousButtonIconColor;
			_diamondIcon.color = _previousDiamondIconColor;
			_txt.color = _previousTxtColor;
		}
		
		private void SetButtonState(UIButtonState state)
		{
			Color color = Color.white;
			switch(state)
			{
				case UIButtonState.Selected:
					_diamondIcon.enabled = true;
					color = _selectedColor;
					_isSelected = true;
					break;
				case UIButtonState.Unselected:
					_diamondIcon.enabled = false;
					color = _unselectedColor;
 					_isSelected = false;
					break;
				case UIButtonState.Hovered:
					color = _hoveredColor;
					break;
			}
			
			_buttonIcon.color = color;
			_diamondIcon.color = color;
			_txt.color = color;
		}
	}
}