namespace MN.Runtime.TopBar.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class TopBarButtonView : MonoBehaviour, IView
	{
		public event Action<TopBarButtonView> OnButtonClicked;
		
		[SerializeField] 
		private Color _selectedColor;
		
		[SerializeField] 
		private Color _unselectedColor;
		
		[SerializeField]
		private Image _buttonIcon;

		[SerializeField]
		private Image _diamondIcon;
		
		[SerializeField]
		private Image _arrowIcon;

		[SerializeField]
		private TMP_Text _txt;
		
		private Button _button;
		
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }

		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			_button = GetComponentInChildren<Button>();
			_button.onClick.AddListener(OnOnButtonClicked);

			Unselect();
				
			IsInitialized = true;
		}
		
		public void Unselect()
		{
			_buttonIcon.color = _unselectedColor;
			_diamondIcon.enabled = false;
			_txt.color = _unselectedColor;
		}

		private void Select()
		{
			_buttonIcon.color = _selectedColor;
			_diamondIcon.enabled = true;
			_txt.color = _selectedColor;
		}

		private void OnOnButtonClicked()
		{
			// MN:TODO: animations, sounds, etc...
			OnButtonClicked?.Invoke(this);
			
			Select();
		}
	}
}