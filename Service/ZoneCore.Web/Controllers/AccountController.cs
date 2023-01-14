using Microsoft.AspNetCore.Mvc;

namespace ZoneCore.Web.Controllers
{
    /// <summary>
    /// 處理使用者不再認證權限內的時候，使用者相關的業務
    /// </summary>
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
