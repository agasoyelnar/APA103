using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
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
