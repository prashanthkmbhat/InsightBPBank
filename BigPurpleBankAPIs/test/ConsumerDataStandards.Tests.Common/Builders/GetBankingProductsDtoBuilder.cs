using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Tests.Common
{
    public class GetBankingProductsDtoBuilder
	{
		private GetBankingProductsDto _dto = new GetBankingProductsDto();
        
        public GetBankingProductsDtoBuilder WithBrand(string value)
		{
			_dto.Brand = value;
			return this;
		}

        public GetBankingProductsDtoBuilder WithEffective(string value)
        {
            _dto.Effective = value;
            return this;
        }
        public GetBankingProductsDtoBuilder WithProductCategory(string value)
        {
            _dto.ProductCategory = value;
            return this;
        }
        public GetBankingProductsDtoBuilder WithUpdatedSince(string value)
        {
            _dto.UpdatedSince = value;
            return this;
        }
        public GetBankingProductsDtoBuilder WithPage(int value)
        {
            _dto.Page = value;
            return this;
        }
        public GetBankingProductsDtoBuilder WithPageSize(int value)
        {
            _dto.PageSize = value;
            return this;
        }

        public GetBankingProductsDtoBuilder WithDefaultValues()
		{
			_dto = new GetBankingProductsDto
            {
                Brand = "test-brand",
                Effective = "CURRENT",
                ProductCategory = BankingProductCategory.BUSINESS_LOANS,
                UpdatedSince = "2024-06-23T10:00:00Z",
                Page = 1,
                PageSize = 1
            };

            return this;
        }

        public GetBankingProductsDto Build() => _dto;
	}
}

