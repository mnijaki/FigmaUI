namespace MN.Runtime.UI.LimitedOffer.Controller
{
	using Core.Controller;
	using Core.Ctx;
	using View;

	public class LimitedOfferController : BaseController<LimitedOfferView>
	{
		public LimitedOfferController(LimitedOfferView limitedOfferView) : base(limitedOfferView)
		{
		}
		
		public override void Initialize(IContext context)
		{
			if(IsInitialized)
			{
				return;
			}
			
			Context = context;

			IsInitialized = true;
		}
	}	
}