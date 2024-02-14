using CartAPI.Dtos;
using CartAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CartAPI.Extensions;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo _cartRepo;
        public CartController(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        [HttpGet]
        public IEnumerable<CartDto> GetAll()
        {
            var cartItems = _cartRepo.GetCarts().Select(item => Extension.AsDto(item));

            return cartItems;
        }

        [HttpPost("{id}")]
        public IActionResult CreateOrder(Guid id)
        {
            var existingCart = _cartRepo.GetCart(id);

            if (existingCart == null)
            {
                return Ok("Add product to checkout!");
            }

            return Ok(new { existingCart, message= "Thanks For CheckOut" });
        }
    }
}
