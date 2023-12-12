namespace MN.Runtime.UI.BottomBar.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class BottomBarButtonController: BaseController<BottomBarButtonView>
	{
		public BottomBarButtonController(BottomBarButtonView bottomBarButtonView) : base(bottomBarButtonView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			Context.CommandManager.AddCommandListener<BottomBarUnselectButtonCommand>(OnBottomBarUnselectButtonCommand);
			_view.OnClicked += OnButtonClicked;

			IsInitialized = true;
		}

		private void OnButtonClicked(BottomBarButtonView view)
		{
			Context.CommandManager.InvokeCommand(new BottomBarButtonClickedCommand());
		}

		private void OnBottomBarUnselectButtonCommand(BottomBarUnselectButtonCommand command)
		{
			_view.Unselect();
		}
	}
}