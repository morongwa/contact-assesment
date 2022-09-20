using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contact.app.mvc.Filter;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace contact.app.mvc.Controllers
{

    [FilterAuth]
    public class DashboardController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

