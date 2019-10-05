using CoffeeManagement.Models;

namespace CoffeeManagement.ViewModels
{
    public class VM_OrderDetails
    {
        public long Id { get; set; }

        public long ProductId { get; set; }
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public long OrderId { get; set; }

        public double LinePrice { get; set; }
    }
}