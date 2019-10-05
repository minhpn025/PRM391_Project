using CoffeeManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeManagement.ViewModels
{
    public class VM_Order
    {
        public VM_Order()
        {

        }

        public IPagedList<VM_OrderInfo> Orders { get; set; }
    }

    /// <summary>
    /// Index page
    /// </summary>
    public class VM_OrderInfo
    {
        public VM_OrderInfo(Order order, IEnumerable<OrderStatus> statuses)
            => (Id, CustomerName, CustomerPhoneNumber, Status, Statuses, TotalPrice, OrderDate)
            = (order.Id, order.CustomerName, order.CustomerPhoneNumber, (int)order.Status,
                statuses.Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = x == order.Status
                }), 
            order.TotalPrice, order.OrderDate);

        public static IEnumerable<VM_OrderInfo> CreateList(IEnumerable<Order> orders, IEnumerable<OrderStatus> statuses)
            => orders.Select(x => new VM_OrderInfo(x, statuses));

        public long Id { get; private set; }

        public string CustomerName { get; private set; }

        public string CustomerPhoneNumber { get; private set; }

        public int Status { get; private set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }

        public double TotalPrice { get; private set; }

        public DateTime OrderDate { get; private set; }
    }
}