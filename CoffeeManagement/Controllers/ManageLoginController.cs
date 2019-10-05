using CoffeeManagement.Models;
using CoffeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeManagement.Controllers
{
    public class ManageLoginController : Controller
    {
        private CoffeeContext _context;

        public ManageLoginController()
        {
            _context = new CoffeeContext();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VM_Login admin)
        {
            if (ModelState.IsValid)
            {
                var currentAdmin = _context.Admins
                .FirstOrDefault(x => x.Username.ToLower() == admin.Username.ToLower() && x.Password == admin.Password);
                if (currentAdmin == null)
                {
                    ModelState.AddModelError("", "Username or Password is not correct.");
                }
                else
                {
                    return RedirectToAction("Index", "ManageProduct");
                }
            } 
                return View("Index");
        }
    }
}