namespace JarusInsuranceQuotation.Api.Data
{
    public class AdditionalInsured
    {
        public int AdditonalInsuredId { get; set; }
        public string QuoteId { get; set; }
        public Person Person { get; set; }
        public int Coverage { get; set; }
    }
}
