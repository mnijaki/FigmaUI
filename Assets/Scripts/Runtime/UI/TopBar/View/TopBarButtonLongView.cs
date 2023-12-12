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

	public class TopBarButtonLongView : MonoBehaviour, IView
	{
		public event Action<TopBarButtonLongView> OnClicked;
		
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
		private Image _backgroundImage;
		
		[SerializeField] 
		private Image _backgroundFillImage;
		
		[SerializeField] 
		private Image _lineImage;
		
		[SerializeField]
		private TMP_Text _txt;

		private bool _isSelected;
		private Color _previousBackgroundImageColor;
		private Color _previousBackgroundFillImageColor;
		private Color _previousLineImageColor;
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
			_previousBackgroundImageColor = _backgroundImage.color;
			_previousBackgroundFillImageColor = _backgroundFillImage.color;
			_previousLineImageColor = _lineImage.color;
			_previousTxtColor = _txt.color;
		}
		
		private void RestoreButtonProperties()
		{
			_backgroundImage.color = _previousBackgroundImageColor;
			_backgroundFillImage.color = _previousBackgroundFillImageColor;
			_lineImage.color = _previousLineImageColor;
			_txt.color = _previousTxtColor;
		}
		
		private void SetButtonState(UIButtonState state)
		{
			Color color = Color.white;
			switch(state)
			{
				case UIButtonState.Selected:
					color = _selectedColor;
					_isSelected = true;
					break;
				case UIButtonState.Unselected:
					color = _unselectedColor;
					_isSelected = false;
					break;
				case UIButtonState.Hovered:
					color = _hoveredColor;
					break;
			}
			
			_backgroundImage.color = color;
			_backgroundFillImage.color = color;
			_lineImage.color = color;
			_txt.color = color;
		}
	}
}