using System;
using SebastianFeistl.Winky.Core;

namespace SebastianFeistl.Winky.Compliance
{
    public class LegalController : Controller<LegalData>
    {
        public event Action TermsAndConditionsAccepted = () => { };
        
        public LegalController(LegalData data) : base(data)
        {
            
        }

        public void AcceptTermsAndConditions()
        {
            Data.AcceptedTermsAndConditionsAt = DateTime.Now;
        }
    }
}