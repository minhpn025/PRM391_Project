using CoffeeManagement.Models;
using CoffeeManagement.ViewModels;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;

namespace CoffeeManagement.Controllers
{
    public class ManageProductController : Controller
    {
        private readonly CoffeeContext _context;

        public ManageProductController()
        {
            _context = new CoffeeContext();
        }

        public ViewResult Index(int? pageIndex, int? pageSize)
        {
            return View(new ManageProductViewModels
            {
                Products = _context.Products.Include(x => x.Category)
                                            .OrderBy(x => x.ProductName)
                                            .ToPagedList(pageIndex ?? 1, pageSize ?? 10),
            });
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName)
                                                        .ToList()
                                                        .Select(x => new SelectListItem
                                                        {
                                                            Text = x.CategoryName,
                                                            Value = x.Id.ToString(),
                                                        });
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.ProductName = product.ProductName.Trim();
            if (_context.Products.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower()))
            {
                ModelState.AddModelError("ProductName", "Product Name already exists!");
                ViewBag.Categories = LoadCategories(null);
                return View();
            }
            else
            {
                product.CreatedBy = "";
                product.CreatedDate = System.DateTime.Now;
                product.UpdatedBy = "";
                product.UpdatedDate = System.DateTime.Now;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                ViewBag.Categories = LoadCategories(product.CategoryId);
                return View(product);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            product.ProductName = product.ProductName.Trim();
            if (_context.Products.Any(x => x.ProductName.ToLower() == product.ProductName.ToLower()
                                        && x.Id != product.Id))
            {
                ModelState.AddModelError("ProductName", "Product Name already exists!");
                ViewBag.Categories = LoadCategories(null);
                return View();
            }
            else
            {
                var currentProduct = _context.Products.FirstOrDefault(x => x.Id == product.Id);
                currentProduct.UpdatedBy = "";
                currentProduct.UpdatedDate = System.DateTime.Now;
                TryUpdateModel(currentProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult DeleteOneProduct(long id)
        {
            var currentProduct = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(currentProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public JsonResult DeleteOneProduct(int id)
        //{
        //    var currentProduct = _context.Products.FirstOrDefault(x => x.Id == id);
        //    _context.Products.Remove(currentProduct);
        //    _context.SaveChanges();
        //    return Json(new
        //    {
        //    });
        //}

        private IEnumerable<SelectListItem> LoadCategories(long? productCategoryId)
        {
            return _context.Categories.OrderBy(x => x.CategoryName)
                                                    .ToList()
                                                    .Select(x => new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.Id.ToString(),
                                                        Selected = x.Id == productCategoryId,
                                                    });

        }
    }
}