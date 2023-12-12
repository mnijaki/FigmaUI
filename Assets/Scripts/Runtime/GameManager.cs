using UnityEngine;

namespace MN.Runtime
{
    using MN.UI.Runtime;
    using TopBar.View;
    using UI.BackButton.View;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TopBarView _topBarView;
        
        [SerializeField]
        private BackButtonView _backButtonView;
        
        protected void Start()
        {
            Installer installer = new(_topBarView, _backButtonView);
            installer.Initialize();
        }
    }
}