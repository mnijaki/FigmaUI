using UnityEngine;

namespace MN.Runtime
{
    using Core.Ctx;
    using TopBar;
    using TopBar.View;

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TopBarView _topBarView;
        
        private Context _context;
        
        protected void Start()
        {
            _context = new Context();
            
            TopBarMVC topBarMVC = new(_context, _topBarView);
            topBarMVC.Initialize();
        }
    }
}