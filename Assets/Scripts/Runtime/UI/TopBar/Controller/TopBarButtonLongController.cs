namespace MN.Runtime.UI.TopBar.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class TopBarButtonLongController : BaseController<TopBarButtonLongView>
	{
		public TopBarButtonLongController(TopBarButtonLongView topBarButtonLongView) : base(topBarButtonLongView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			Context.CommandManager.AddCommandListener<TopBarUnselectButtonLongCommand>(OnTopBarUnselectButtonLongCommand);
			
			_view.OnClicked += OnClicked;

			IsInitialized = true;
		}

		private void OnClicked(TopBarButtonLongView view)
		{
			Context.CommandManager.InvokeCommand(new TopBarButtonLongClickedCommand());
		}

		private void OnTopBarUnselectButtonLongCommand(TopBarUnselectButtonLongCommand command)
		{
			_view.Unselect();
		}
	}
}