namespace MN.Runtime.UI.BackButton.View
{
	using System;
	using Core.Ctx;
	using Core.View;
	using UnityEngine;
	using UnityEngine.UI;

	public class BackButtonView : MonoBehaviour, IView
	{
		public event Action OnClicked;
		
		public bool IsInitialized { get; private set; }
		public IContext Context { get; private set; }
		
		[SerializeField] 
		private Color _hoveredColor;
		[SerializeField] 
		private Vector2 _clickedScale = new Vector2(0.9F, 0.9F);
		[SerializeField] 
		private Image _arrowImage;
		[SerializeField] 
		private Image _diamondImage;
		
		private Color _previousArrowImageColor;
		private Color _previousDiamondImageColor;
		private Vector2 _previousScale;
		
		public void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			SubscribeToPointerEvents();
				
			IsInitialized = true;
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
			OnClicked?.Invoke();
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
			_previousArrowImageColor = _arrowImage.color;
			_previousDiamondImageColor = _diamondImage.color;
		}
		
		private void RestoreButtonProperties()
		{
			_arrowImage.color = _previousArrowImageColor;
			_diamondImage.color = _previousDiamondImageColor;
			transform.localScale = Vector2.one;
		}
		
		private void SetButtonState(UIButtonState state)
		{
			Color color = Color.white;
			switch(state)
			{
				case UIButtonState.Selected:
					break;
				case UIButtonState.Unselected:
					break;
				case UIButtonState.Hovered:
					color = _hoveredColor;
					break;
			}
			
			_arrowImage.color = color;
			_diamondImage.color = color;
		}
	}
}