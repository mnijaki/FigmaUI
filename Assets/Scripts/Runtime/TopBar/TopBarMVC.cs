namespace MN.Runtime.TopBar
{
	using Core;
	using Core.Ctx;
	using View;

	public class TopBarMVC : MVC<Context, TopBarModel, TopBarView, TopBarController, TopBarService>
	{
		public TopBarMVC(Context context, TopBarView view)
		{
			Context = context;
			View = view;
		}

		public override void Initialize()
		{
			if(IsInitialized)
			{
				return;
			}
			
			// Model
			//OPTION 1: Create it, pass it in
			//OPTION 2: Create it in the RightMini
			//OPTION 3: Create it in the LeftMini
			Model = new TopBarModel();
			Model.Initialize(Context);
			
			View.Initialize(Context);
			
			Service = new TopBarService();
			
			Controller = new TopBarController(Model, View, Service);
			Controller.Initialize(Context);
			
			IsInitialized = true;
		}
	}
}