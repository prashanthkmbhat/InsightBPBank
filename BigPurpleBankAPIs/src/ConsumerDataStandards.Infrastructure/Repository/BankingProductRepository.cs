using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text;
using System.Xml.Linq;
using ConsumerDataStandards.Core.Exceptions;
using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;
using ConsumerDataStandards.Infrastructure.Config;
using Dapper;
using static System.Net.Mime.MediaTypeNames;

namespace ConsumerDataStandards.Infrastructure.Repository
{
    public class BankingProductRepository : IBankingProductRepository
    {
        protected readonly string ConnectionString;
        public BankingProductRepository(DatabaseConfig configuration)
        {
            ConnectionString = configuration.ConnectionString ?? "";
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);

        }
        public async Task<List<BankingProductV4>> GetBankingProducts(GetBankingProductsDto bankingProductsDto)
        {
            var whereConditions = new StringBuilder();

            whereConditions.Append($"where brand = @Brand");
            switch (bankingProductsDto.Effective)
            {
                case Effective.ALL: break;
                case Effective.FUTURE: whereConditions.Append($" and effectiveFrom > @Effective and effectiveTo > @Effective"); break;
                case Effective.CURRENT:
                default:
                    whereConditions.Append($" and effectiveFrom < @Effective and effectiveTo > @Effective"); break;
            }

            whereConditions.Append($" and productCategory = @ProductCategory");
            if (bankingProductsDto.UpdatedSince != null)
            {
                whereConditions.Append($" and lastUpdated > @LastUpdated");
            }

            var orderbyCondition = "lastUpdated DESC";
            //whereConditions.Append($" order by lastUpdated DESC OFFSET {bankingProductsDto.Page * bankingProductsDto.PageSize} ROWS FETCH NEXT {bankingProductsDto.PageSize} ROWS ONLY");

            await using var conn = new SqlConnection(ConnectionString);
            var queryResult = await conn.GetListPagedAsync<BankingProductV4>(bankingProductsDto.Page.GetValueOrDefault(),
                                                                             bankingProductsDto.PageSize.GetValueOrDefault(),
                                                                             whereConditions.ToString(),
                                                                             orderbyCondition,
                                                                             new
                                                                             {
                                                                                 bankingProductsDto.Brand,
                                                                                 Effective = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ssZ"),
                                                                                 bankingProductsDto.ProductCategory,
                                                                                 LastUpdated = bankingProductsDto.UpdatedSince
                                                                             });



            if (queryResult == null || !queryResult.Any())
            {
                throw new BankingProductNotFoundException("No Products Found");
            }

            return queryResult.ToList();

        }
    }
}