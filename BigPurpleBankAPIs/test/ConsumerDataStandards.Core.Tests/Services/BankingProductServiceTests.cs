using System;
using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Exceptions;
using ConsumerDataStandards.Core.Models;
using ConsumerDataStandards.Tests.Common;
using ConsumerDataStandards.UnitTests.Fixtures;
using FluentAssertions;
using Moq;

namespace ConsumerDataStandards.UnitTests.Services
{
	public class BankingProductServiceTests
	{
		[Fact]
		public async Task GetProducts_ReturnsProductsFromDb_GivenValidInputParameters()
		{
			//Arrange
			var fixture = new BankingProductServiceFixture();
			var inputDto = new GetBankingProductsDtoBuilder()
                           .WithDefaultValues()
						   .Build();
			var expectedResult = new List<BankingProductV4>{
									new BankingProductV4Builder()
									.WithDefaultValues()
									.Build(),
									new BankingProductV4Builder()
									.WithDefaultValues()
									.WithProductCategory(BankingProductCategory.OVERDRAFTS)
									.Build()};

            fixture.MockBankingProductRepository.Setup(x => x.GetBankingProducts(It.IsAny<GetBankingProductsDto>())).ReturnsAsync(expectedResult);

			//Act
			var result = await fixture.Sut().GetProducts(inputDto);

			//Assert
			result.Should().NotBeNull();
			result.Should().BeEquivalentTo(expectedResult);
			fixture.MockBankingProductRepository.Verify(x => x.GetBankingProducts(inputDto), Times.Once());
			fixture.MockBankingProductRepository.VerifyNoOtherCalls();
		}

        [Fact]
        public async Task GetProducts_ThrowsEntityNotFoundException_GivenNoDataAvailableInDb()
        {
            // Arrange
            var fixture = new BankingProductServiceFixture();
            var inputDto = new GetBankingProductsDtoBuilder()
                           .WithDefaultValues()
                           .Build();
			
            fixture.MockBankingProductRepository.Setup(x => x.GetBankingProducts(It.IsAny<GetBankingProductsDto>())).ReturnsAsync(new List<BankingProductV4>());

            // Act
            // Assert
            var exception =
                await Assert.ThrowsAsync<BankingProductNotFoundException>(async () => await fixture.Sut().GetProducts(inputDto));
            exception.Message.Should().Be($"No banking products available in the store");
            fixture.MockBankingProductRepository.Verify(x => x.GetBankingProducts(inputDto), Times.Once());
            fixture.MockBankingProductRepository.VerifyNoOtherCalls();
        }


    }
}

