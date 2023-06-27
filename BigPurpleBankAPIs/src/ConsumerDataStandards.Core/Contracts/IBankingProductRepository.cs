using System;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Core.Contracts
{
	public interface IBankingProductRepository
	{
		Task<List<BankingProductV4>> GetBankingProducts(GetBankingProductsDto bankingProductsDto);
	}
}

