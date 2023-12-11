namespace MN.Runtime.TopBar.View
{
    using System.Collections.Generic;
    using Core.Ctx;
    using Core.View;
    using UnityEngine;

    public class TopBarView : MonoBehaviour, IView
    {
        [SerializeField]
        private List<TopBarButtonView> _buttons;
        
        public List<TopBarButtonView> Buttons => _buttons;

        public bool IsInitialized { get; private set; }
        public IContext Context { get; private set; }

        public void Initialize(IContext context)
        {
            if(IsInitialized)
            {
                return;
            }
            
            Context = context;
            
            // MN:TODO: set initial state of buttons (which one should be selected).
            
            IsInitialized = true;
        }
    }
}
