using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dtos;
using ProductAPI.Repository;
using ProductAPI.Extensions;
using ProductAPI.MessageProduce;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IProducer _producer;
        public ProductController(IProductRepo productRepo, IProducer producer)
        {
            _productRepo = productRepo;
            _producer = producer;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _productRepo.getProducts().Select(product => Extension.AsDto(product));

            return products;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product =  _productRepo.getProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Extension.AsDto(product));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(CUProductDto createProduct)
        {
            var product = Extension.DtoAs(createProduct);

            _productRepo.createProduct(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(Guid id, CUProductDto updateProduct)
        {
            var existingProduct = _productRepo.getProduct(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductName = updateProduct.productName;
            existingProduct.Quantity = updateProduct.quantity;
            existingProduct.UnitPrice = updateProduct.unitprice;

            var result = _productRepo.updateProduct(existingProduct);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            var result = _productRepo.deleteProduct(id);

            return Ok(result);
        }

        [HttpPost("AddToCart/{id}")]
        public async Task<IActionResult> PlaceOrder(Guid id, int Quantity)
        {
            var product = _productRepo.getProduct(id);

            if (product != null && Quantity > 0 && Quantity <= product.Quantity && product.UnitPrice > 0)
            {
                var message = new
                {
                    product.ProductName,
                    Quantity,
                    product.UnitPrice
                };
                await _producer.ProduceMessage(product.Id, message);

                product.Quantity -= Quantity;
                _productRepo.updateProduct(product);

                return Ok("Adding to Cart");
            }
            return BadRequest("Product cannot be added to cart");
        }
    }
}
