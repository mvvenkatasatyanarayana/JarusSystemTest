using System;
using System.Collections.Generic;

namespace JarusInsuranceQuotation.Api.Data
{
    public class Quote
    {
        public string QuoteId { get; set; }
        public int StatusId { get; set; }
        public List<Status> Statuses { get; set; }
        public string Applicant { get; set; }
        public DateTime QuoteDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Basic { get; set; }
        public string Preffered { get; set; }
        public string Premier { get; set; }
    }
}
