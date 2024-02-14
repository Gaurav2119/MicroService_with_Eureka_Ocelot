using CartAPI.Models;

namespace CartAPI.Repository
{
    public interface ICartRepo
    {
        IEnumerable<CartEntity> GetCarts();
        CartEntity GetCart(Guid id);
        void createCart(CartEntity cart);
        bool updateCart(CartEntity cart);
        bool deleteCart(Guid id);
    }
}
