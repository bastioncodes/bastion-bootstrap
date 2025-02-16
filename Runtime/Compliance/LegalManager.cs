using System;
using Bastion.Core;

namespace Bastion.Compliance
{
    public class LegalManager : Manager
    {
        private readonly LegalController _controller;
        
        public event Action TermsAndConditionsAccepted = () => { };
        
        public LegalManager(LegalController controller)
        {
            _controller = controller;
        }

        protected override void Start(Action onComplete = null, Action<Exception> onError = null)
        {
            _controller.TermsAndConditionsAccepted += () => { TermsAndConditionsAccepted(); };
            onComplete?.Invoke();
        }
    }
}