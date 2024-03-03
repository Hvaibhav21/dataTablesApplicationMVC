using dapperProject.Models;
using Dapper;
using dataTablesApplicationMVC.Data;
using dataTablesApplicationMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace dataTablesApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly ILogger<HomeController> _logger;
        public EmployeeController(ILogger<HomeController> logger, EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            
            var employees = GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }

            return Json(new
            {
                aaData = employees
            });
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var sqlQuery = "Select * from Employees";
            try
            {
                using (var db = _employeeDbContext.CreateConnection())
                {
                    var emp = db.Query<Employee>(sqlQuery);
                    return emp;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
