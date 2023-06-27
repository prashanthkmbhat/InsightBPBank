using ConsumerDataStandards.Core.Dtos;
using ConsumerDataStandards.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using ConsumerDataStandards.Core.Models;
using System.Net;
using ConsumerDataStandards.Core.Exceptions;

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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<BankingProductV4>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] GetBankingProductsDto getBankingProductsDto)
        {
            try
            {
                return Ok(await _productService.GetProducts(getBankingProductsDto));
            }
            catch (BankingProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
    }
}
