namespace MN.Runtime.TopBar.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UI;
	using UnityEngine;
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
		
		[SerializeField] 
		private Color _hoverColor;
		
		[SerializeField]
		private Image _buttonIcon;

		[SerializeField]
		private Image _diamondIcon;

		[SerializeField]
		private TMP_Text _txt;

		private bool _isSelected;
		private PointerHandler _pointerHandler;
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
			
			_pointerHandler = GetComponentInChildren<PointerHandler>();
			_pointerHandler.OnPointerClicked += OnPointerClick;
			_pointerHandler.OnPointerEntered += OnPointerEnter;
			_pointerHandler.OnPointerExited += OnPointerExit;

			Unselect();
				
			IsInitialized = true;
		}

		public void Unselect()
		{
			_buttonIcon.color = _unselectedColor;
			_diamondIcon.enabled = false;
			_diamondIcon.color = _unselectedColor;
			_txt.color = _unselectedColor;

			_isSelected = false;
		}

		private void Select()
		{
			_buttonIcon.color = _selectedColor;
			_diamondIcon.enabled = true;
			_diamondIcon.color = _selectedColor;
			_txt.color = _selectedColor;
			
			_previousButtonIconColor = _buttonIcon.color;
			_previousDiamondIconColor = _diamondIcon.color;
			_previousTxtColor = _txt.color;

			_isSelected = true;
		}

		private void OnPointerClick(PointerHandler pointerHandler)
		{
			// MN:TODO: animations, sounds, etc...
			OnClicked?.Invoke(this);
			
			Select();
		}

		private void OnPointerEnter(PointerHandler pointerHandler)
		{
			if(_isSelected)
			{
				return;
			}
			
			_previousButtonIconColor = _buttonIcon.color;
			_previousDiamondIconColor = _diamondIcon.color;
			_previousTxtColor = _txt.color;
				
			_buttonIcon.color = _hoverColor;
			_diamondIcon.color = _hoverColor;
			_txt.color = _hoverColor;
		}
		
		private void OnPointerExit(PointerHandler pointerHandler)
		{
			_buttonIcon.color = _previousButtonIconColor;
			_diamondIcon.color = _previousDiamondIconColor;
			_txt.color = _previousTxtColor;
		}
	}
}