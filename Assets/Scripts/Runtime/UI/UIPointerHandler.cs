namespace MN.Runtime.UI
{
	using System;
	using UnityEngine.EventSystems;
	using UnityEngine.UI;
	
	#if UNITY_EDITOR
	using UnityEditor;

	[CustomEditor(typeof(UIPointerHandler))]
	public class UIPointerHandler_Editor : Editor
	{
		// Override OnInspectorGUI to remove the default Inspector GUI elements.
		public override void OnInspectorGUI(){}
	}
	#endif

	/// <summary>
	///   Custom class for handling pointer events.
	///	  Inherits from Text to allow GraphicRaycaster to work.
	/// </summary>
	public class UIPointerHandler : Text, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		public event Action<UIPointerHandler> OnPointerClicked;
		public event Action<UIPointerHandler> OnPointerEntered;
		public event Action<UIPointerHandler> OnPointerExited;
		public event Action<UIPointerHandler> OnPointerDowned;
		public event Action<UIPointerHandler> OnPointerUpped;

		public void OnPointerClick(PointerEventData eventData)
		{
			OnPointerClicked?.Invoke(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			OnPointerEntered?.Invoke(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			OnPointerExited?.Invoke(this);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			OnPointerDowned?.Invoke(this);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			OnPointerUpped?.Invoke(this);
		}
	}
}