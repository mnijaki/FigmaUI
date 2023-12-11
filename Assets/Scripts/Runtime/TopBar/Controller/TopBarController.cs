namespace MN.Runtime.TopBar
{
	using System;
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using UnityEngine;
	using View;

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
			Context.CommandManager.AddCommandListener<TopBarButtonClickedCommand>(OnTopBarButtonClickedCommand);

			InitializeButtons();
				
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
		
		public void InitializeButtons()
		{
			foreach (TopBarButtonView buttonView in _view.Buttons)
			{
				TopBarButtonModel buttonModel = new TopBarButtonModel();
				string key = buttonView.GetInstanceID().ToString();
				buttonModel.Initialize(Context, key);
				
				buttonView.Initialize(Context);
				
				TopBarButtonController controller = new TopBarButtonController(buttonModel, buttonView);
				controller.Initialize(Context);
			}
		}

		private void OnTopBarButtonClickedCommand(TopBarButtonClickedCommand command)
		{
			Context.CommandManager.InvokeCommand(new TopBarUnselectButtonCommand());
			
			// If we want to handle more sophisticated logic, we can do it here and also add another command if
			// we want to inject ourselves between the process of clicking.
			// Example: loading data of shop, closing modal dialogs, etc...
			// Context.CommandManager.InvokeCommand(new TopBarSelectButtonCommand(command.ClickedButton));
		}
	}
}