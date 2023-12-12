namespace MN.Runtime.UI
{
	using BackButton.Controller;
	using BackButton.View;
	using Core;
	using Core.Ctx;
	using LeftMenu.Controller.Command;
	using LeftMenu.View;
	using TopBar.Controller;
	using TopBar.View;

	public class UIInstaller : IMVC
	{
		public bool IsInitialized  { get; private set; }
		public Context Context { get; private set; }
		
		private readonly TopBarView _topBarView;
		private readonly BackButtonView _backButtonView;
		private readonly LeftMenuView _leftMenuView;
		
		public UIInstaller(TopBarView topBarView, BackButtonView backButtonView, LeftMenuView leftMenuView)
		{
			_topBarView = topBarView;
			_backButtonView = backButtonView;
			_leftMenuView = leftMenuView;
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
	}
}