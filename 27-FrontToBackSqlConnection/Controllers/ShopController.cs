using Microsoft.AspNetCore.Mvc;

namespace FrontToBackSqlConnection.Controllers;

public class ShopController:Controller
{
    public IActionResult Index()
    {
        return View();  
    }
}