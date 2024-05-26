
using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVwebApplication.Controllers
{
    public class loginController : Controller
    {
        private readonly loginModel login;
        
        public loginController()
        {
            login = new loginModel();
        }

        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            var loginModel = new loginModel();
            int userId = loginModel.SelectUser(email, name);
            if (userId != -1)
            {

                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                return RedirectToAction("My Work", new { userId = userId});
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("signUp");
            }
        }
    }
}
