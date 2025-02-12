﻿using System;
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

        public override void Initialize(Action onComplete = null, Action<Exception> onError = null)
        {
            _controller.TermsAndConditionsAccepted += () => { TermsAndConditionsAccepted(); };
            onComplete?.Invoke();
        }
    }
}