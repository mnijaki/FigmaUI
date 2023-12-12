namespace MN.Runtime.UI.LeftMenu.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class LeftMenuButtonView : MonoBehaviour, IView
	{
		public event Action<LeftMenuButtonView> OnClicked;
		
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }
		
		[SerializeField] 
		private Color _selectedColor;
		[SerializeField] 
		private Color _unselectedColor;
		[SerializeField] 
		private Color _hoveredColor;
		[SerializeField]
		private Image _selectedLineImage;
		[SerializeField]
		private Image _unselectedLineImage;
		[SerializeField]
		private TMP_Text _txt;
		
		private bool _isSelected;
		private Color _previousTxtColor;
		private Color _previousSelectedLineImageColor;
		private Color _previousUnselectedLineImageColor;
		
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

		public void Select()
		{
			SetButtonState(UIButtonState.Selected);
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
			
			CacheButtonProperties();
			SetButtonState(UIButtonState.Hovered);
		}
		
		private void OnPointerExited(UIPointerHandler pointerHandler)
		{
			if(_isSelected)
			{
				return;
			}
			
			RestoreButtonProperties();
		}

		private void CacheButtonProperties()
		{
			_previousSelectedLineImageColor = _selectedLineImage.color;
			_previousUnselectedLineImageColor = _unselectedLineImage.color;
			_previousTxtColor = _txt.color;
		}
		
		private void RestoreButtonProperties()
		{
			_selectedLineImage.color = _previousSelectedLineImageColor;
			_unselectedLineImage.color = _previousUnselectedLineImageColor;
			_txt.color = _previousTxtColor;
		}
		
		private void SetButtonState(UIButtonState state)
		{
			Color color = Color.white;
			switch(state)
			{
				case UIButtonState.Selected:
					color = _selectedColor;
					_selectedLineImage.enabled = true;
					_unselectedLineImage.enabled = false;
					_isSelected = true;
					break;
				case UIButtonState.Unselected:
					color = _unselectedColor;
					_selectedLineImage.enabled = false;
					_unselectedLineImage.enabled = true;
 					_isSelected = false;
					break;
				case UIButtonState.Hovered:
					color = _hoveredColor;
					break;
			}
			
			_selectedLineImage.color = color;
			_unselectedLineImage.color = color;
			_txt.color = color;
		}
	}
}