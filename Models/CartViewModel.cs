using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CartViewModel : ControllerBase
    {
        public Customer Customer { get; set; }

        public CartViewModel(IList<Item> items)
        {
            Items = items;
        }
        public CartViewModel(IList<Item> itens, Customer customer)
        {
            Customer = customer;
            Items = itens;
        }

        public IList<Item> Items { get; }

        public decimal Total => Items.Sum(i => i.Quantity * i.Price);
    }
}
