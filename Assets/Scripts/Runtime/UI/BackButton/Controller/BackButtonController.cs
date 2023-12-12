namespace MN.Runtime.UI.BackButton.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class BackButtonController : BaseController<BackButtonView> 
	{
		public BackButtonController(BackButtonView backButtonView) : base(backButtonView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			_view.OnClicked += OnClicked;

			IsInitialized = true;
		}
		
		private void OnClicked()
		{
			Context.CommandManager.InvokeCommand(new BackButtonClickedCommand());
		}
	}
}