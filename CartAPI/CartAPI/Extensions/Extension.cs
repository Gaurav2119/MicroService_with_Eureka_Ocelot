using CartAPI.Dtos;
using CartAPI.Models;

namespace CartAPI.Extensions
{
    public class Extension
    {
        public static CartDto AsDto(CartEntity cart)
        {
            return new CartDto(cart.Id, cart.productId, cart.productName, cart.quantityOrdered, cart.UnitPrice);
        }

        public static CartEntity DtoAs(CreateCartDto createproduct)
        {
            return new CartEntity
            {
                Id = Guid.NewGuid(),
                productId = createproduct.ProductId,
                productName = createproduct.ProductName,
                quantityOrdered = createproduct.QuantityOrdered,
                UnitPrice = createproduct.unitprice
            };
        }
    }
}
