using Microsoft.AspNetCore.Mvc;

namespace ZoneCore.Web.Controllers.Common
{
    public class ComponentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
