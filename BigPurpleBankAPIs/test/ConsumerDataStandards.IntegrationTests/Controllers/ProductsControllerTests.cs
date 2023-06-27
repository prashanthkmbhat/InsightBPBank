using System;
using ConsumerDataStandards.Core.Models;
using ConsumerDataStandards.Tests.Common;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace ConsumerDataStandards.IntegrationTests.Controllers
{
	public class ProductsControllerTests
	{
		private HttpClient _httpClient;

		public ProductsControllerTests()
		{
			var webApplicationFactory = new WebApplicationFactory<Program>();
			_httpClient = webApplicationFactory.CreateDefaultClient();
		}

		[Fact]
		public async Task GetProducts_ReturnsProductsList_GivenValidInput()
		{
			//?Effective=adsgas&UpdatedSince=asdgsa&Brand=asdg&ProductCategory=1&Page=1&PageSize=1

			var inputDto = new GetBankingProductsDtoBuilder()
				.WithDefaultValues()
				.WithBrand("ABC-Bank")
				.WithEffective("CURRENT")
				.WithProductCategory(BankingProductCategory.BUSINESS_LOANS)
				.WithUpdatedSince(DateTime.UtcNow.ToString("yyyy:MM:ddThh:mm:ssZ"))
				.WithPage(1)
				.WithPageSize(5)
				.Build();

            var queryParameters = $"Effective={inputDto.Effective}&UpdatedSince={inputDto.UpdatedSince}&" +
				$"Brand={inputDto.Brand}&ProductCategory={inputDto.ProductCategory}&" +
				$"Page={inputDto.Page}&PageSize={inputDto.PageSize}";

            var response = await _httpClient.GetAsync($"/api/products?{queryParameters}");
			var result = JsonConvert.DeserializeObject<IEnumerable<BankingProductV4>>(await response.Content.ReadAsStringAsync());
            result.Should().NotBeNullOrEmpty();
        }
	}
}

