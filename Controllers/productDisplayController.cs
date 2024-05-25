using Microsoft.AspNetCore.Mvc;
using CLDVwebApplication.Models;

namespace CLDVwebApplication.Controllers
{
    public class productDisplayController : Controller
    {
        private productTable _productTable = new();
        [HttpGet]
        public ActionResult insertProducts(productTable products)
        {
            var result2 = _productTable.insert_product(products);
            return RedirectToAction("Products", "Home");
        }

        [HttpGet]
        public ActionResult insertProducts()
        {
            return View(_productTable);
        }
    }
}