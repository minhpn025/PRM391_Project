using CoffeeManagement.Models;
using CoffeeManagement.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeManagement.Controllers
{
    public class ManageOrderController : Controller
    {
        private readonly CoffeeContext _context;

        public ManageOrderController()
        {
            _context = new CoffeeContext();
        }

        // GET: ManageOrder
        [HttpGet]
        public ActionResult Index(int? pageIndex, int? pageSize)
        {
            var orders = _context.Orders;
            var statuses = LoadOrderStatuses<OrderStatus>();
            var result = VM_OrderInfo.CreateList(orders, statuses)
                .ToPagedList(pageIndex ?? 1, pageSize ?? 5);

            return View(new VM_Order
            {
                Orders = result,
            });
        }

        [HttpGet]
        public JsonResult updateOrderStatus(long orderId, int currentStatus)
        {
            var currentOrder = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            OrderStatus currStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), currentStatus.ToString());
            currentOrder.Status = currStatus;
            _context.SaveChanges();
            return Json(currentOrder, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        private IEnumerable<T> LoadOrderStatuses<T>() where T : struct, IConvertible
            => Enum.GetValues(typeof(T)).Cast<T>();

        [HttpGet]
        public ActionResult ViewOrderDetails(long id)
        {
            var currentOrder = _context.Orders.Include(x => x.OrderDetails)
                .Include(x => x.OrderDetails.Select(y => y.Product))
                .FirstOrDefault(x => x.Id == id);
            return View(currentOrder);
        }
    }
}