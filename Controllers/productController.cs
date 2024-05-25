using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDVwebApplication.Controllers
{
    public class productController : Controller
    {
        public productTable prodtbl = new productTable();

        [HttpPost]
        public ActionResult myWork(productTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult myWork()
        {
            return View(prodtbl);
        }
    }
}
