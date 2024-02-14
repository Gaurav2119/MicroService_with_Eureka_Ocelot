using ProductAPI.Dtos;
using ProductAPI.Entity;

namespace ProductAPI.Repository
{
    public interface IProductRepo
    {
        IEnumerable<ProductEntity> getProducts();
        ProductEntity getProduct(Guid id);

        void createProduct(ProductEntity product);
        bool updateProduct(ProductEntity product);
        bool deleteProduct(Guid id);
    }
}
