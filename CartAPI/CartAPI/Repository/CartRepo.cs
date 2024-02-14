using CartAPI.Models;

namespace CartAPI.Repository
{
    public class CartRepo : ICartRepo
    {
        private static readonly List<CartEntity> _cartEntities = new List<CartEntity>();

        public void createCart(CartEntity cart)
        {
            _cartEntities.Add(cart);

        }

        public bool deleteCart(Guid id)
        {
            var index = _cartEntities.FindIndex(existingCart => existingCart.Id == id);

            if (index < 0)
            {
                return false;
            }

            _cartEntities.RemoveAt(index);
            return true;
        }

        public IEnumerable<CartEntity> GetCarts()
        {
            return _cartEntities;
        }

        public CartEntity GetCart(Guid id)
        {
            return _cartEntities.SingleOrDefault(cart => cart.Id == id);
        }

        public bool updateCart(CartEntity cart)
        {
            var index = _cartEntities.FindIndex(existingCart => existingCart.Id == cart.Id);

            if (index < 0)
            {
                return false;
            }

            _cartEntities[index] = cart;
            return true;
        }
    }
}
