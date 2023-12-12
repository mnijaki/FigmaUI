namespace MN.Runtime.UI
{
	using BackButton.View;
	using Core;
	using Core.Ctx;
	using TopBar.Controller;
	using TopBar.View;

	public class UIInstaller : IMVC
	{
		public bool IsInitialized  { get; private set; }
		public Context Context { get; private set; }
		
		private TopBarView _topBarView;
		private BackButtonView _backButtonView;
		
		public UIInstaller(TopBarView topBarView, BackButtonView backButtonView)
		{
			_topBarView = topBarView;
			_backButtonView = backButtonView;
		}

		public void Initialize()
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = new Context();

			InstallTopBar();
			
			IsInitialized = true;
		}

		private void InstallTopBar()
		{
			TopBarController topBarController = new(_topBarView);
			_topBarView.Initialize(Context);
			topBarController.Initialize(Context);
		}
	}
}