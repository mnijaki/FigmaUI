namespace MN.Runtime.UI.TopBar.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using TMPro;
	using UnityEngine;
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
		
		[SerializeField] 
		private Color _hoveredColor;
		
		[SerializeField] 
		private float _hoveredScaleX = 1.1F;
		
		[SerializeField] 
		private float _clickedScaleX = 0.9F;

		[SerializeField] 
		private Image _backgroundImage;
		
		[SerializeField] 
		private Image _backgroundFillImage;
		
		[SerializeField] 
		private Image _lineImage;
		
		[SerializeField]
		private TMP_Text _txt;

		
		private Vector2 _hoveredScale;
		private Vector2 _clickedScale;
		private Color _previousBackgroundImageColor;
		private Color _previousBackgroundFillImageColor;
		private Color _previousLineImageColor;
		private Color _previousTxtColor;
		private Vector2 _previousScale;

		
		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			_hoveredScale = new Vector2(_hoveredScaleX, 1.0F);
			_clickedScale = new Vector2(_clickedScaleX, 1.0F);
			
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
			CacheButtonProperties();
		}
		
		private void SubscribeToPointerEvents()
		{
			UIPointerHandler pointerHandler = GetComponentInChildren<UIPointerHandler>();
			pointerHandler.OnPointerClicked += OnPointerClicked;
			pointerHandler.OnPointerEntered += OnPointerEntered;
			pointerHandler.OnPointerExited += OnPointerExited;
			pointerHandler.OnPointerDowned += OnPointerDowned;
			pointerHandler.OnPointerUpped += OnPointerUpped;
		}
		
		private void OnPointerDowned(UIPointerHandler obj)
		{
			Transform trans = transform;
			_previousScale = trans.localScale;
			trans.localScale = _clickedScale;
		}

		private void OnPointerClicked(UIPointerHandler pointerHandler)
		{
			// MN:TODO: animations, sounds, etc...
			OnClicked?.Invoke(this);
			
			Select();
		}

		private void OnPointerUpped(UIPointerHandler obj)
		{
			transform.localScale = _previousScale;
		}

		private void OnPointerEntered(UIPointerHandler pointerHandler)
		{
			CacheButtonProperties();
			SetButtonState(UIButtonState.Hovered);
		}
		
		private void OnPointerExited(UIPointerHandler pointerHandler)
		{
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
			transform.localScale = Vector2.one;
		}
		
		private void SetButtonState(UIButtonState state)
		{
			Color color = Color.white;
			switch(state)
			{
				case UIButtonState.Selected:
					color = _selectedColor;
					break;
				case UIButtonState.Unselected:
					color = _unselectedColor;
					break;
				case UIButtonState.Hovered:
					color = _hoveredColor;
					transform.localScale = _hoveredScale;
					break;
			}
			
			_backgroundImage.color = color;
			_backgroundFillImage.color = color;
			_lineImage.color = color;
			_txt.color = color;
		}
	}
}