using ConsumerDataStandards.Core.Exceptions;
using ConsumerDataStandards.Core.Models;
using ConsumerDataStandards.Tests.Common;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
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
				.WithBrand("NAB")
				.WithEffective("CURRENT")
				.WithProductCategory(BankingProductCategory.TERM_DEPOSITS)
				.WithUpdatedSince(DateTime.UtcNow.AddDays(-20).ToString("yyyy-MM-dd hh:mm:ss"))
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


        [Fact]
        public async Task GetProducts_ReturnsProductsList_GivenInValidInput()
        {
            //?Effective=adsgas&UpdatedSince=asdgsa&Brand=asdg&ProductCategory=1&Page=1&PageSize=1

            var inputDto = new GetBankingProductsDtoBuilder()
                .WithDefaultValues()
                .WithBrand("NAB GHGH")
                .WithEffective("CURRENT")
                .WithProductCategory(BankingProductCategory.TERM_DEPOSITS)
                .WithUpdatedSince(DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss"))
                .WithPage(1)
                .WithPageSize(5)
                .Build();

            var queryParameters = $"Effective={inputDto.Effective}&UpdatedSince={inputDto.UpdatedSince}&" +
                $"Brand={inputDto.Brand}&ProductCategory={inputDto.ProductCategory}&" +
                $"Page={inputDto.Page}&PageSize={inputDto.PageSize}";

            var response = await _httpClient.GetAsync($"/api/products?{queryParameters}");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            var result = await response.Content.ReadAsStringAsync();
            result.Should().Be("No banking products available in the store");
        }
    }
}

