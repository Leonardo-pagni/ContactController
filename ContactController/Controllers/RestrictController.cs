using ContactController.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers
{
    [UserLogin]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
