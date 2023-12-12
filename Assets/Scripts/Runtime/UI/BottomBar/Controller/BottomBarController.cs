namespace MN.Runtime.UI.BottomBar.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class BottomBarController : BaseController<BottomBarView>
	{
		public BottomBarController(BottomBarView bottomBarView) : base(bottomBarView)
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
			SelectButton();
			SubscribeToCommands();

			IsInitialized = true;
		}

		private void InitializeButtons()
		{
			foreach (BottomBarButtonView buttonView in _view.Buttons)
			{
				buttonView.Initialize(Context);
				BottomBarButtonController controller = new(buttonView);
				controller.Initialize(Context);
			}
		}

		private void SelectButton()
		{
			_view.Buttons[0].Select();
		}

		private void SubscribeToCommands()
		{
			Context.CommandManager.AddCommandListener<BottomBarButtonClickedCommand>(OnBottomBarButtonClickedCommand);
		}

		private void OnBottomBarButtonClickedCommand(BottomBarButtonClickedCommand command)
		{
			Context.CommandManager.InvokeCommand(new BottomBarUnselectButtonCommand());
			
			// If we want to handle more sophisticated logic, we can do it here and also add another command if
			// we want to inject ourselves between the process of clicking.
			// Example: loading data of shop, closing modal dialogs, etc...
			// Context.CommandManager.InvokeCommand(new TopBarSelectButtonCommand(command.ClickedButton));
		}
	}
}