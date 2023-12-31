﻿using System.Data.SqlClient;
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
            ConnectionString = configuration.DBConnectionString ?? "";
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLServer);

        }
        public async Task<List<BankingProductV4>> GetBankingProducts(GetBankingProductsDto bankingProductsDto)
        {
            var whereConditions = new StringBuilder();
            if(bankingProductsDto.Effective == null)
            {
                bankingProductsDto.Effective = "CURRENT";
            }
            switch (bankingProductsDto.Effective)
            {
                case Effective.ALL: whereConditions.Append($"where effectiveFrom > '2000-01-01 00:00:00'"); break;
                case Effective.FUTURE: whereConditions.Append($"where effectiveFrom > @Effective and effectiveTo > @Effective "); break;
                case Effective.CURRENT:
                default:
                    whereConditions.Append($"where effectiveFrom < @Effective and effectiveTo > @Effective "); break;
            }
            if (bankingProductsDto.Brand != null)
            {
                whereConditions.Append($" and brand = @Brand");
            }
            if (bankingProductsDto.ProductCategory != null)
            {
                whereConditions.Append($" and productCategory = @ProductCategory");
            }
            if (bankingProductsDto.UpdatedSince != null)
            {
                whereConditions.Append($" and lastUpdated > @LastUpdated");
            }

            var orderbyCondition = "lastUpdated DESC";
            //whereConditions.Append($" order by lastUpdated DESC OFFSET {bankingProductsDto.Page * bankingProductsDto.PageSize} ROWS FETCH NEXT {bankingProductsDto.PageSize} ROWS ONLY");

            await using var conn = new SqlConnection(ConnectionString);
            var queryResult = await conn.GetListPagedAsync<BankingProductV4>(bankingProductsDto.Page.GetValueOrDefault(1),
                                                                             bankingProductsDto.PageSize.GetValueOrDefault(10),
                                                                             whereConditions.ToString(),
                                                                             orderbyCondition,
                                                                             new
                                                                             {
                                                                                 bankingProductsDto.Brand,
                                                                                 Effective = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ssZ"),
                                                                                 bankingProductsDto.ProductCategory,
                                                                                 LastUpdated = bankingProductsDto.UpdatedSince
                                                                             });


            return queryResult == null ? new List<BankingProductV4>() : queryResult.ToList();

        }
    }
}