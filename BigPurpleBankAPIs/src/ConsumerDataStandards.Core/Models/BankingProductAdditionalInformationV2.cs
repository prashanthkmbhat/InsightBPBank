namespace ConsumerDataStandards.Core.Models
{
    public class BankingProductAdditionalInformationV2
	{
		public string? OverviewUri { get; set; }
		public string? TermsUri { get; set; }
		public string? EligibilityUri { get; set; }
		public string? FeesAndPricingUri { get; set; }
		public string? BundleUri { get; set; }
		public BankingProductAdditionalInformationV2_additionalInformationUris? AdditionalOverviewUris { get; set; }
        public BankingProductAdditionalInformationV2_additionalInformationUris? AdditionalTermsUris { get; set; }
        public BankingProductAdditionalInformationV2_additionalInformationUris? AdditionalEligibilityUris { get; set; }
        public BankingProductAdditionalInformationV2_additionalInformationUris? AdditionalFeesAndPricingUris { get; set; }
        public BankingProductAdditionalInformationV2_additionalInformationUris? AdditionalBundleUris { get; set; }
    }
}

