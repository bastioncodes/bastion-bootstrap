using System;
using Bastion.Core;

namespace Bastion.Compliance
{
    public class LegalController : Controller<LegalData>
    {
        public event Action TermsAndConditionsAccepted = () => { };
        
        public LegalController(LegalData data) : base(data)
        {
            //
        }

        public void AcceptTermsAndConditions()
        {
            ModelData.AcceptedTermsAndConditionsAt = DateTime.Now;
            TermsAndConditionsAccepted();
        }
    }
}