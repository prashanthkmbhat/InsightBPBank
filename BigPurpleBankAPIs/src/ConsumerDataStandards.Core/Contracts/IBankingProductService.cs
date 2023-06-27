using System;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Core.Contracts
{
    public interface IBankingProductService
    {
        Task<List<BankingProductV4>> GetProducts(GetBankingProductsDto bankingProductsDto);
    }
}

