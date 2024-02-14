using ProductAPI.Dtos;
using ProductAPI.Entity;

namespace ProductAPI.Extensions
{
    public class Extension
    {
        public static ProductDto AsDto(ProductEntity product)
        {
            return new ProductDto(product.Id, product.ProductName, product.Quantity, product.UnitPrice);
        }

        public static ProductEntity DtoAs(CUProductDto cuproduct)
        {
            return new ProductEntity
            {
                Id = Guid.NewGuid(),
                ProductName = cuproduct.productName,
                Quantity = cuproduct.quantity,
                UnitPrice = cuproduct.unitprice
            };
        }
    }
}
