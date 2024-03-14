using System;
using System.Runtime.Serialization;
using SebastianFeistl.Winky.Core;

namespace SebastianFeistl.Winky.Compliance
{
    public class LegalData : Data
    {
        [DataMember(Name = "accepted_terms_and_conditions_at")]
        public DateTime AcceptedTermsAndConditionsAt { get; set; }
        
        [DataMember(Name = "has_accepted_terms_and_conditions")]
        public bool HasAcceptedTermsAndConditions => AcceptedTermsAndConditionsAt != DateTime.MinValue;
    }
}