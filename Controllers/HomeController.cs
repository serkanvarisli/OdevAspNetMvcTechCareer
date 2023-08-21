using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev.Models;
using Odev.ViewModel;

namespace Odev.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _context =  new MyDbContext();

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Orders(int employeeId)
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.EmployeeId == employeeId)
                .ToList();
            return View(orders);
        }

        public IActionResult Products(int orderId)
        {
            var products = _context.OrderDetails
                .Where(o => o.OrderId == orderId)
                .Select(o=>new ProductsViewModel
                {
                    ProductName = o.Product.ProductName,
                    Quantity = o.Quantity
                })
                .ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult Profile(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);

			return View(employee);
        }
        [HttpPost]
        public IActionResult UpdateProfile(Employee updateEmployee)
        {
            _context.Employees.Update(updateEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index", new { employeeId = updateEmployee.EmployeeId });
        }

    }
}