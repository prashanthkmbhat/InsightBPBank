using System;
using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Core.Services
{
	public class BankingProductService : IBankingProductService
	{
        private readonly IBankingProductRepository _bankingProductRepository;

        public BankingProductService(IBankingProductRepository bankingProductRepository)
		{
            _bankingProductRepository = bankingProductRepository;
        }

        public async Task<List<BankingProductV4>> GetProducts(GetBankingProductsDto bankingProductsDto)
        {
            return await _bankingProductRepository.GetBankingProducts(bankingProductsDto);
        }
    }
}

