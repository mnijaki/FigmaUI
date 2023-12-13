namespace MN.Runtime
{
    using UI;
    using UI.BackButton.View;
    using UI.BottomBar.View;
    using UI.LeftMenu.View;
    using UI.LimitedOffer.View;
    using UI.TopBar.View;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TopBarView _topBarView;
        
        [SerializeField]
        private BackButtonView _backButtonView;
        
        [SerializeField]
        private LeftMenuView _leftMenuView;
        
        [SerializeField]
        private BottomBarView _bottomBarView;
        
        [SerializeField]
        private LimitedOfferView _limitedOfferView;
        
        protected void Start()
        {
            UIInstaller uiInstaller = new(_topBarView, _backButtonView, _leftMenuView, _bottomBarView, _limitedOfferView);
            uiInstaller.Initialize();
        }
    }
}