using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
