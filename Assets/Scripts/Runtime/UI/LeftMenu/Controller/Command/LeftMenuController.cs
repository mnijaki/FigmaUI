namespace MN.Runtime.UI.LeftMenu.Controller.Command
{
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class LeftMenuController : BaseController<LeftMenuView> 
	{
		public LeftMenuController(LeftMenuView leftMenuView) : base(leftMenuView)
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
			foreach (LeftMenuButtonView buttonView in _view.Buttons)
			{
				buttonView.Initialize(Context);
				LeftMenuButtonController controller = new(buttonView);
				controller.Initialize(Context);
			}
		}

		private void SelectButton()
		{
			_view.Buttons[0].Select();
		}

		private void SubscribeToCommands()
		{
			Context.CommandManager.AddCommandListener<LeftMenuButtonClickedCommand>(OnLeftMenuButtonClickedCommand);
		}

		private void OnLeftMenuButtonClickedCommand(LeftMenuButtonClickedCommand command)
		{
			Context.CommandManager.InvokeCommand(new LeftMenuUnselectButtonCommand());
			
			// If we want to handle more sophisticated logic, we can do it here and also add another command if
			// we want to inject ourselves between the process of clicking.
			// Example: loading data of shop, closing modal dialogs, etc...
			// Context.CommandManager.InvokeCommand(new TopBarSelectButtonCommand(command.ClickedButton));
		}
	}
}