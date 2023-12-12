namespace MN.Runtime.UI.TopBar.View
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Ctx;
    using Core.View;
    using UnityEngine;

    public class TopBarView : MonoBehaviour, IView
    {
        public List<TopBarButtonView> Buttons { get; private set; }
        public TopBarButtonLongView ButtonLong { get; private set; }

        public bool IsInitialized { get; private set; }
        public IContext Context { get; private set; }

        public void Initialize(IContext context)
        {
            if(IsInitialized)
            {
                return;
            }
            
            Context = context;

            Buttons = GetComponentsInChildren<TopBarButtonView>().ToList();
            ButtonLong = GetComponentInChildren<TopBarButtonLongView>();
            
            // MN:TODO: set initial state of buttons (which one should be selected).
            
            IsInitialized = true;
        }
    }
}