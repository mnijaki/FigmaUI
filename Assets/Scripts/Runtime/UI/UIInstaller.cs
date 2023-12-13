namespace MN.Runtime.UI
{
	using BackButton.Controller;
	using BackButton.View;
	using BottomBar.Controller;
	using BottomBar.View;
	using Core;
	using Core.Ctx;
	using LeftMenu.Controller.Command;
	using LeftMenu.View;
	using LimitedOffer.Controller;
	using LimitedOffer.View;
	using TopBar.Controller;
	using TopBar.View;

	public class UIInstaller : IMVC
	{
		public bool IsInitialized  { get; private set; }
		public Context Context { get; private set; }
		
		private readonly TopBarView _topBarView;
		private readonly BackButtonView _backButtonView;
		private readonly LeftMenuView _leftMenuView;
		private readonly BottomBarView _bottomBarView;
		private readonly LimitedOfferView _limitedOfferView;
		
		public UIInstaller(TopBarView topBarView, BackButtonView backButtonView, LeftMenuView leftMenuView, 
		                   BottomBarView bottomBarView, LimitedOfferView limitedOfferView)
		{
			_topBarView = topBarView;
			_backButtonView = backButtonView;
			_leftMenuView = leftMenuView;
			_bottomBarView = bottomBarView;
			_limitedOfferView = limitedOfferView;
		}

		public void Initialize()
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = new Context();

			InstallTopBar();
			InstallBackButton();
			InstallLeftMenu();
			InstallBottomBar();
			InstallLimitedOffer();
			
			IsInitialized = true;
		}

		private void InstallTopBar()
		{
			TopBarController topBarController = new(_topBarView);
			_topBarView.Initialize(Context);
			topBarController.Initialize(Context);
		}

		private void InstallBackButton()
		{
			BackButtonController backButtonController = new(_backButtonView);
			_backButtonView.Initialize(Context);
			backButtonController.Initialize(Context);
		}
		
		private void InstallLeftMenu()
		{
			LeftMenuController leftMenuController = new(_leftMenuView);
			_leftMenuView.Initialize(Context);
			leftMenuController.Initialize(Context);
		}
		
		private void InstallBottomBar()
		{
			BottomBarController bottomBarController = new(_bottomBarView);
			_bottomBarView.Initialize(Context);
			bottomBarController.Initialize(Context);
		}
		
		private void InstallLimitedOffer()
		{
			LimitedOfferController limitedOfferController = new(_limitedOfferView);
			_limitedOfferView.Initialize(Context);
			limitedOfferController.Initialize(Context);
		}
	}
}