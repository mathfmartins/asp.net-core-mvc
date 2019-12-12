using System;
using System.Collections.Generic;
using System.Linq;


namespace ECommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime Data { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public int Teste { get; set; }
        public decimal Total
        {
            get
            {
                return Items.Sum(i => i.Total);
            }
        }
    }
}