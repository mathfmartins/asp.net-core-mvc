using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;
using Newtonsoft.Json;
using ECommerce.Data;
using System.Linq;
using System;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Buy(int id)
        {
            Order order;
            try
            {
                order = JsonConvert
                .DeserializeObject<Order>(HttpContext.Session
                    .GetString("cart"));
            }
            catch
            {
                order = new Order();
            }

            using (var data = new ProductData())
            {
                Product product = data.Read(id);

                Item item = order.Items
                    .SingleOrDefault(i => i.Product.Id == id);

                if(item == null)
                {
                    order.Items.Add(new Item{
                        Product = product,
                        Quantity = 1,
                        Price = product.Price
                    });
                    if (true)
                    {
                        Console.WriteLine("");
                    }
                }
                else
                {
                    item.Quantity++;
                }
            }
            HttpContext.Session.SetString("cart",
                 JsonConvert.SerializeObject(order));
            

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            Order order;
            try
            {
                order = JsonConvert
                .DeserializeObject<Order>(HttpContext.Session
                    .GetString("cart"));
            }
            catch
            {
                order = new Order();
            }

            var cartViewModel = new CartViewModel(order.Items);
            return View(cartViewModel);
        }
    }
}