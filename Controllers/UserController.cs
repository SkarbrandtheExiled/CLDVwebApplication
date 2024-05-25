using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;
namespace CLDVwebApplication.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

    [HttpPost]
    public ActionResult signUp(userTable Users)
    {
        var result = usrtbl.insert_user(Users);
        return RedirectToAction("Login", "Home");
    }
    [HttpGet]

    public IActionResult signUp() {
        return View(usrtbl);
        }
    }
}
