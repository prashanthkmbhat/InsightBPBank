using System.Drawing.Drawing2D;
using System.Xml.Linq;
using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Infrastructure
{
    public class BankingProductRepository : IBankingProductRepository
    {
        public async Task<List<BankingProductV4>> GetBankingProducts(GetBankingProductsDto bankingProductsDto)
        {
            //DateTime updatedSince;
            //var isValidDateInput = DateTime.TryParse(bankingProductsDto.UpdatedSince, out updatedSince);
            return new List<BankingProductV4>() {
                new BankingProductV4 {
                     ProductId = "123456",
                    EffectiveFrom = DateTime.UtcNow.AddDays(-1),
                    EffectiveTo = DateTime.UtcNow.AddYears(1),
                    LastUpdated = DateTime.UtcNow.AddDays(1),
                    ProductCategory = BankingProductCategory.BUSINESS_LOANS,
                    Name = "Dummy Savings Account",
                    Description = "This is a dummy savings account",
                    Brand = "Dummy Bank",
                    BrandName = "Dummy Bank",
                    ApplicationUri = "https://www.dummybank.com/apply",
                    IsTailored = false,
                    AdditionalInformation = new BankingProductAdditionalInformationV2{},
                    Title = "Dummy Banking Product",
                    ImageUri = "https://www.dummybank.com/images/product.png"

                }
            };
        }
    }
}