using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Entity
{
    public class ProductEntity
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
    }
}
