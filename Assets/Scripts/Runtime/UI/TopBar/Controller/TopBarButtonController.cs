namespace MN.Runtime.TopBar
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class TopBarButtonController : BaseController<TopBarButtonModel, TopBarButtonView>
	{
		public TopBarButtonController(TopBarButtonModel topBarButtonModel, TopBarButtonView topBarButtonView) : base(topBarButtonModel, topBarButtonView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			Context.CommandManager.AddCommandListener<TopBarUnselectButtonCommand>(OnTopBarUnselectButtonCommand);
			
			_view.OnClicked += OnClicked;

			IsInitialized = true;
		}

		private void OnClicked(TopBarButtonView view)
		{
			Context.CommandManager.InvokeCommand(new TopBarButtonClickedCommand());
		}

		private void OnTopBarUnselectButtonCommand(TopBarUnselectButtonCommand command)
		{
			_view.Unselect();
		}
	}
}