namespace MN.Runtime.UI.TopBar.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using Model;
	using View;
	using Service;

	public class TopBarController : BaseController<TopBarModel, TopBarView, TopBarService> 
	{
		public TopBarController(TopBarModel topBarModel, TopBarView topBarView, TopBarService topBarService) : base(topBarModel, topBarView, topBarService)
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
			
				
			//
			//_model.SceneName.Value = SceneManager.GetActiveScene().name;
                
			//
			//_view.OnScorePoints.AddListener(View_OnScorePoints);
			//_view.OnReset.AddListener(View_OnReset);
                
			//
			//_service.OnLoadCompleted.AddListener(Service_OnLoadCompleted);
			//_service.Load();

			IsInitialized = true;
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

		private void InitializeButtons()
		{
			string key;
			foreach (TopBarButtonView buttonView in _view.Buttons)
			{
				TopBarButtonModel buttonModel = new();
				key = buttonView.GetInstanceID().ToString();
				buttonModel.Initialize(Context, key);
				
				buttonView.Initialize(Context);
				
				TopBarButtonController controller = new(buttonModel, buttonView);
				controller.Initialize(Context);
			}

			TopBarButtonLongModel buttonLongModel = new();
			key = _view.ButtonLong.GetInstanceID().ToString();
			buttonLongModel.Initialize(Context, key);
				
			_view.ButtonLong.Initialize(Context);
				
			TopBarButtonLongController controllerLong = new(buttonLongModel, _view.ButtonLong);
			controllerLong.Initialize(Context);
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