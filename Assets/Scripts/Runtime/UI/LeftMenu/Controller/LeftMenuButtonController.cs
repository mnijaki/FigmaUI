namespace MN.Runtime.UI.LeftMenu.Controller
{
	using Command;
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class LeftMenuButtonController : BaseController<LeftMenuButtonView>
	{
		public LeftMenuButtonController(LeftMenuButtonView leftMenuButtonView) : base(leftMenuButtonView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;
			
			Context.CommandManager.AddCommandListener<LeftMenuUnselectButtonCommand>(OnLeftMenuUnselectButtonCommand);
			_view.OnClicked += OnButtonClicked;

			IsInitialized = true;
		}

		private void OnButtonClicked(LeftMenuButtonView view)
		{
			Context.CommandManager.InvokeCommand(new LeftMenuButtonClickedCommand());
		}

		private void OnLeftMenuUnselectButtonCommand(LeftMenuUnselectButtonCommand command)
		{
			_view.Unselect();
		}
	}
}