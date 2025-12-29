using Microsoft.AspNetCore.Mvc;

namespace ExtCharlist.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
