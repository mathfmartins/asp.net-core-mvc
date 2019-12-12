using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ECommerce.Models;
using ECommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using(var data = new ProductData())
                return View(data.Read());            
        }

        public IActionResult Create()
        {
            using (var data = new CategoryData())
            {
                var list = data.Read();
                ViewBag.Categories = list;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }

            using(var data = new ProductData())
                data.Create(e);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using(var data = new ProductData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(var data = new CategoryData())
            {
                var list = data.Read();
                ViewBag.Categories = list;
            }

            using(var data = new ProductData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Product product)
        {
            product.Id = id;    

            if(!ModelState.IsValid)
                return View(product);
        
            using(var data = new ProductData())
                data.Update(product);

            return RedirectToAction("Index");
        }
    }
}