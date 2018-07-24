using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Site.Controllers
{
    [Authorize]
    public class PagamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
