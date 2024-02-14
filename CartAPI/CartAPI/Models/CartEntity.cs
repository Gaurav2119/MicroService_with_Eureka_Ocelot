namespace CartAPI.Models
{
    public class CartEntity
    {
        public Guid Id { get; set; }
        public Guid productId { get; set; }

        public string productName { get; set; }
        public int quantityOrdered { get; set; }
        public double UnitPrice { get; set; }
    }
}
