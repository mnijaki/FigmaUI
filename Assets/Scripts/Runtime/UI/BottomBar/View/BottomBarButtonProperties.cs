namespace MN.Runtime.UI.BottomBar.View
{
	using System;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	[Serializable]
	public class BottomBarButtonProperties
	{
		// MN:TODO: this should be divided into smaller pieces (eg. Serializable classes or even own View/ViewComponent)
		[SerializeField]
		private Image _downloadNowBackgroundImage;
		[SerializeField]
		private Image _downloadNowImage;
		[SerializeField]
		private TMP_Text _downloadNowTxt;
		[SerializeField]
		private Image _getDataBackgroundImage;
		[SerializeField]
		private Image _getDataNowImage;
		[SerializeField]
		private TMP_Text _getDataNowTxt;
		[SerializeField]
		private Image _background;
		[SerializeField]
		private Image _bottomLine;
		[SerializeField]
		private Image _statsLineLongImage;
		[SerializeField]
		private Image _statsLineShortImage;
		[SerializeField]
		private Image _skinImage;
		[SerializeField]
		private Image _setSkinImage1;
		[SerializeField]
		private Image _setSkinImage2;
		[SerializeField]
		private Image _setSkinImage3;
		[SerializeField]
		private Image _setCircleImage;
		[SerializeField]
		private TMP_Text _skinNameTxt;
		[SerializeField]
		private Image _costImage;
		[SerializeField]
		private TMP_Text _priceTxt;
		[field: SerializeField]
		public GameObject DownloadNowGO { get; private set; }
		[field: SerializeField]
		public GameObject GetDataGO { get; private set; }

		public void SetTheme(BottomBarButtonTheme theme)
		{
			_downloadNowBackgroundImage.color = theme.DownloadNowBackgroundImageColor;
			_downloadNowImage.color = theme.DownloadNowImageColor;
			_downloadNowTxt.color = theme.DownloadNowTxtColor;
			_getDataBackgroundImage.color = theme.GetDataBackgroundImageColor;
			_getDataNowImage.color = theme.GetDataNowImageColor;
			_getDataNowTxt.color = theme.GetDataNowTxtColor;
			_background.color = theme.BackgroundColor;
			_bottomLine.color = theme.BottomLineColor;
			_statsLineLongImage.color = theme.StatsLineLongImageColor;
			_statsLineShortImage.color = theme.StatsLineShortImageColor;
			_skinImage.color = theme.SkinImageColor;
			_setSkinImage1.color = theme.SetSkinImage1Color;
			_setSkinImage2.color = theme.SetSkinImage2Color;
			_setSkinImage3.color = theme.SetSkinImage3Color;
			_setCircleImage.color = theme.SetCircleImageColor;
			_skinNameTxt.color = theme.SkinNameTxtColor;
			_costImage.color = theme.CostImageColor;
			_priceTxt.color = theme.PriceTxtColor;
		}
	}
}