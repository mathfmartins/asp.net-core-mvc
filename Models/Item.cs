namespace ECommerce.Models
{
    public class Item
    {
        //Propriedades & atributos
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; } // is - a

        public decimal Total
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}