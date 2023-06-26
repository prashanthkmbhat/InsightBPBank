using System;
using ConsumerDataStandards.Core.Models;

namespace ConsumerDataStandards.Core.Dtos
{
	public class GetBankingProductsDto
	{
		public string? Effective { get; set; }
		public string? UpdatedSince { get; set; }
		public string? Brand { get; set; }
		public string? ProductCategory { get; set; }
		public int? Page { get; set; }
		public int? PageSize { get; set; }
	}
}

