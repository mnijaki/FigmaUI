namespace MN.Runtime.UI.BottomBar.View
{
	using UnityEngine;

	/// <summary>
	///   Example of a theme for bottom bar button.
	/// </summary>
	[CreateAssetMenu(fileName="BottomBarButtonTheme", menuName = "Bottom bar/Button/Create new theme for bottom bar button", order = 1)]
	public class BottomBarButtonTheme : ScriptableObject
	{
		// MN:TODO: this should be divided into smaller pieces (eg. Serializable classes or even own View/ViewComponent)
		[field: SerializeField]
		public Color DownloadNowBackgroundImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color DownloadNowImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color DownloadNowTxtColor { get; private set; } = Color.white;
		
		[field: SerializeField]
		public Color GetDataBackgroundImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color GetDataNowImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color GetDataNowTxtColor { get; private set; } = Color.white;
		
		[field: SerializeField]
		public Color BackgroundColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color BottomLineColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color StatsLineLongImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color StatsLineShortImageColor { get; private set; } = Color.white;
		
		[field: SerializeField]
		public Color SkinImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color SetSkinImage1Color { get; private set; } = Color.white;
		[field: SerializeField]
		public Color SetSkinImage2Color { get; private set; } = Color.white;
		[field: SerializeField]
		public Color SetSkinImage3Color { get; private set; } = Color.white;
		[field: SerializeField]
		public Color SetCircleImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color SkinNameTxtColor { get; private set; } = Color.white;
		
		[field: SerializeField]
		public Color CostImageColor { get; private set; } = Color.white;
		[field: SerializeField]
		public Color PriceTxtColor { get; private set; } = Color.white;
	}
}