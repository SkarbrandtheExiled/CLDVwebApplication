using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVwebApplication.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtb = new userTable();

    [HttpPost]

    public ActionResult About(userTable Users)
    {
        var result = usrtb.insert_user(Users);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult About() {
        return View(usrtb);
        }
    }
}
