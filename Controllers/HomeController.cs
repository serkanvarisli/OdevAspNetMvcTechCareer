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
            var orders = _context.OrderDetails
                .Include(o=>o.Order)
                .ThenInclude(o => o.Customer)
                .Include(o=>o.Product)
                .Where(o => o.Order.EmployeeId == employeeId)
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

        public IActionResult Profile(int employeeId)
        {
            var employee = _context.Employees.Where(e => e.EmployeeId == employeeId).ToList();

			return View(employee);
        }
        //[HttpPost]
        //public IActionResult UpdateProfile(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
        //        if (existingEmployee != null)
        //        {
        //            existingEmployee.FirstName = employee.FirstName;
        //            existingEmployee.LastName = employee.LastName;
        //            existingEmployee.Title = employee.Title;
        //            // Diğer özellikler
        //            _context.SaveChanges();
        //            return RedirectToAction("Profile", new { employeeId = existingEmployee.EmployeeID });
        //        }
        //    }
        //    return View("Profile", employee);
        //}
    }
}