using ConsumerDataStandards.Core.Contracts;
using ConsumerDataStandards.Core.Services;
using Moq;

namespace ConsumerDataStandards.UnitTests.Fixtures
{
	public class BankingProductServiceFixture
	{
		public Mock<IBankingProductRepository> MockBankingProductRepository { get; }

		public BankingProductServiceFixture()
		{
			MockBankingProductRepository = new Mock<IBankingProductRepository>();
		}

		public BankingProductService Sut()
		{
			return new BankingProductService(MockBankingProductRepository.Object);
		}
	}
}

