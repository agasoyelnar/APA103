using Microsoft.AspNetCore.Mvc;

namespace MVCIntro.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if(id is null || id < 0){
                return RedirectToAction(nameof(Error));
            }
            return RedirectToAction(nameof(Index),"Product");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
