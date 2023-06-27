using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Tests.Common
{
    public class BankingProductV4Builder
	{
		private BankingProductV4 _product = new BankingProductV4();
        
        public BankingProductV4Builder WithBrand(string value)
		{
			_product.Brand = value;
			return this;
		}
        public BankingProductV4Builder WithEffectiveFrom(DateTime? value)
        {
            _product.EffectiveFrom = value;
            return this;
        }
        public BankingProductV4Builder WithEffectiveTo(DateTime? value)
        {
            _product.EffectiveTo = value;
            return this;
        }
        public BankingProductV4Builder WithProductCategory(string value)
        {
            _product.ProductCategory = value;
            return this;
        }
        public BankingProductV4Builder LastUpdated(DateTime? value)
        {
            _product.LastUpdated = value;
            return this;
        }
       
        public BankingProductV4Builder WithDefaultValues()
		{
			_product = new BankingProductV4
            {
                Brand = "test-brand",
                EffectiveFrom = DateTime.Parse("2023-06-24T10:00:00Z"),
                EffectiveTo = DateTime.Parse("2023-06-26T10:00:00Z"),
                ApplicationUri = "http://dummy-app/",
                BrandName = "test-brand-name",
                CardArt = null,
                Description = "test-description",
                ImageUri = "https://image-uri",
                IsTailored = true,
                LastUpdated = DateTime.Parse("2023-06-24T19:00:00Z"),
                Name = "test-name",
                ProductCategory = BankingProductCategory.CRED_AND_CHRG_CARDS,
                ProductId = Guid.NewGuid().ToString(),
                Title = "test-title"
            };

            return this;
        }

        public BankingProductV4 Build() => _product;
	}
}

