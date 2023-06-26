using System.Drawing;


namespace ConsumerDataStandards.Core.Models
{
    public class BankingProductV4
	{
        public string? ProductId { get; set; } //Assumed ASCII string
		public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public DateTime? LastUpdated { get; set; }
		public string? ProductCategory { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Brand { get; set; }
		public string? BrandName { get; set; }
		public string? ApplicationUri { get; set; } //Assumed URI string
		public bool? IsTailored { get; set; }
		public BankingProductAdditionalInformationV2? AdditionalInformation { get; set; }
		public List<Image?>? CardArt { get; set; }
		public string? Title { get; set; }
		public string? ImageUri { get; set; } //Assumed URI string
	}

    /*
	 *CREATE TABLE BankingProductV4 (
    ProductId VARCHAR(255),
    EffectiveFrom DATETIME,
    EffectiveTo DATETIME,
    LastUpdated DATETIME,
    ProductCategory INT,
    Name VARCHAR(255),
    Description VARCHAR(255),
    Brand VARCHAR(255),
    BrandName VARCHAR(255),
    ApplicationUri VARCHAR(255),
    IsTailored BIT,
    AdditionalInformationId VARCHAR(255),
    AdditionalInfo1 VARCHAR(255),
    AdditionalInfo2 VARCHAR(255),
    Title VARCHAR(255),
    ImageUri VARCHAR(255)
);

INSERT INTO BankingProductV4 (ProductId, EffectiveFrom, EffectiveTo, LastUpdated, ProductCategory, Name, Description, Brand, BrandName, ApplicationUri, IsTailored, AdditionalInformationId, AdditionalInfo1, AdditionalInfo2, Title, ImageUri)
VALUES ('123456', '2023-06-23 10:00:00', '2024-06-23 10:00:00', '2023-06-23 10:00:00', 1, 'Dummy Savings Account', 'This is a dummy savings account', 'Dummy Bank', 'Dummy Bank', 'https://www.dummybank.com/apply', 0, '789', 'Additional info 1', 'Additional info 2', 'Dummy Banking Product', 'https://www.dummybank.com/images/product.png');
	 */

}

