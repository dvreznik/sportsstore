using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // private fields
        private IProductRepository _repository;

        // constructor
        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }

        // public method
        public ViewResult Edit(int productId) => 
            View(_repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} hes been saved";
                return RedirectToAction("Index");
            }else
            {                
                return View(product);
            }
        }

        // delete product
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = _repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        // create product
        public ViewResult Create() => View("Edit", new Product());

        public ViewResult Index() => View(_repository.Products);
    }
}