using ProductAPI.Entity;

namespace ProductAPI.Repository
{
    public class ProductRepo : IProductRepo
    {
        private static readonly List<ProductEntity> _productEntities = new List<ProductEntity>();

        public void createProduct(ProductEntity product)
        {
            _productEntities.Add(product);
        }

        public bool deleteProduct(Guid id)
        {
            var index = _productEntities.FindIndex(existingProduct => existingProduct.Id == id);

            if (index < 0)
            {
                return false;
            }

            _productEntities.RemoveAt(index);
            return true;
        }

        public ProductEntity getProduct(Guid id)
        {
            return _productEntities.SingleOrDefault(product => product.Id == id);
        }

        public IEnumerable<ProductEntity> getProducts()
        {
            return _productEntities.ToList();
        }

        public bool updateProduct(ProductEntity updateproduct)
        {
            var index = _productEntities.FindIndex(existingProduct => existingProduct.Id == updateproduct.Id);

            if (index < 0)
            {
                return false;
            }
            
            _productEntities[index] = updateproduct;
            return true;
        }
    }
}
