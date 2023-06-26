using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using ConsumerDataStandards.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerDataStandards.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IBankingProductService _productService;
        public ProductsController(IBankingProductService productService)
        {
            _productService = productService;

        }
        // GET: api/products
        [HttpGet]
        public async Task<IEnumerable<BankingProductV4>> Get([FromQuery] GetBankingProductsDto getBankingProductsDto)
        {
            return await _productService.GetProducts(getBankingProductsDto);

        }
       
    }
}
