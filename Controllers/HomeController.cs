using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using WebApplication3.Service;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly EmployeeService _employeeService;
        public readonly IConfiguration _IConfig;
        public HomeController(EmployeeService _employeeService , IConfiguration _IConfig)
        {
            this._employeeService = _employeeService;
            this._IConfig = _IConfig;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employee = _employeeService.GetEmployee(_IConfig.GetConnectionString("SQLConnection"));

            return View(employee);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}