namespace MN.Runtime.UI.TopBar.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class TopBarController : BaseController<TopBarView> 
	{
		public TopBarController(TopBarView topBarView) : base(topBarView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			InitializeButtons();
			SelectButtons();
			SubscribeToCommands();

			IsInitialized = true;
		}

		private void InitializeButtons()
		{
			foreach (TopBarButtonView buttonView in _view.Buttons)
			{
				buttonView.Initialize(Context);
				TopBarButtonController controller = new(buttonView);
				controller.Initialize(Context);
			}
				
			_view.ButtonLong.Initialize(Context);
			TopBarButtonLongController controllerLong = new(_view.ButtonLong);
			controllerLong.Initialize(Context);
		}

		private void SelectButtons()
		{
			_view.Buttons[0].Select();
			_view.ButtonLong.Select();
		}

		private void SubscribeToCommands()
		{
			Context.CommandManager.AddCommandListener<TopBarButtonClickedCommand>(OnTopBarButtonClickedCommand);
			Context.CommandManager.AddCommandListener<TopBarButtonLongClickedCommand>(OnTopBarButtonLongClickedCommand);
		}

		private void OnTopBarButtonClickedCommand(TopBarButtonClickedCommand command)
		{
			Context.CommandManager.InvokeCommand(new TopBarUnselectButtonCommand());
			
			// If we want to handle more sophisticated logic, we can do it here and also add another command if
			// we want to inject ourselves between the process of clicking.
			// Example: loading data of shop, closing modal dialogs, etc...
			// Context.CommandManager.InvokeCommand(new TopBarSelectButtonCommand(command.ClickedButton));
		}
		
		private void OnTopBarButtonLongClickedCommand(TopBarButtonLongClickedCommand command)
		{
			// MN:TODO: add logic later
		}
	}
}