using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moto_shop_test.DTO.ProductDTO;
using moto_shop_test.Models;
using moto_shop_test.Services;

namespace moto_shop_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok("All products:/n" + products);
            }
            catch (Exception)
            {
                return NotFound("List is empty");
            }
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct(ProductDTO productDTO)
        {
            try
            {
                var addProduct = _productService.AddProduct(productDTO);
                return Created("Product added", addProduct);
            }
            catch (Exception)
            {
                return BadRequest("You incorrectly entered product");
            }
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int? id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok($"Product with id: {id} deleted");
            }
            catch (Exception)
            {
                return NotFound($"Product with id: {id} not found");
            }
        }
    }
}
