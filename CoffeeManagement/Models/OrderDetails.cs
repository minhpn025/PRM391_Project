using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeManagement.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        private OrderDetails()
        {
        }

        public OrderDetails(Product product, int quantity)
            => (ProductId, Quantity, LinePrice)
            = (product.Id, quantity, product.Price * quantity);

        [Key]
        public long Id { get; set; }

        [Required]
        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public long OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public double LinePrice { get; set; }
    }
}