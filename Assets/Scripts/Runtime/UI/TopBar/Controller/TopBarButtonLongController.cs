namespace MN.Runtime.TopBar
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class TopBarButtonLongController : BaseController<TopBarButtonLongModel, TopBarButtonLongView>
	{
		public TopBarButtonLongController(TopBarButtonLongModel topBarButtonLongModel, TopBarButtonLongView topBarButtonLongView) : base(topBarButtonLongModel, topBarButtonLongView)
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