using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
