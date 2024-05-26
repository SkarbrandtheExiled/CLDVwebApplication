using CLDVwebApplication.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CLDVwebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly productTable _productTable;

        public ProductController()
        {
            _productTable = new productTable();
        }

        [HttpGet]
        public IActionResult InsertProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertProducts(productTable model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _productTable.insert_product(model);

                    if (result != -1) // or any other condition indicating success
                    {
                        // Product insertion successful
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Handle product insertion failure
                        ModelState.AddModelError("", "Failed to insert the product.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception thrown by insert_product
                    ModelState.AddModelError("", ex.Message);
                }
            }

            // If there are any validation errors, redisplay the form
            return View(model);
        }
    }
}