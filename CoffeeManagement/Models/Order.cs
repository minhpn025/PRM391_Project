using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CoffeeManagement.Models
{
    [Table("Orders")]
    public class Order
    {
        private Order()
        {
        }

        public Order(IEnumerable<OrderDetails> orderDetails)
        {
            Status = OrderStatus.Waiting;
            OrderDate = DateTime.Now;
            OrderDetails = new List<OrderDetails>(orderDetails);

            TotalPrice = orderDetails.Select(x => x.LinePrice).DefaultIfEmpty(0).Sum();
        }

        [Key]
        public long Id { get; set; }

        [Required, MaxLength(255)]
        public string CustomerName { get; set; }

        [Required, MaxLength(255)]
        public string CustomerPhoneNumber { get; set; }

        [Required, MaxLength(255)]
        public string CustomerAddress { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public string Notes { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        Waiting = 1,
        Accepted = 2,
        Delivered = 3,
        Cancelled = 4
    }
}