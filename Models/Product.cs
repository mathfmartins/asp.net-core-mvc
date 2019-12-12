using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Campo nome obrigatório")]
        [MinLength(3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        #region Dados da Categoria
        public int CategoryId { get; set; }
        public string Category { get; set; }
        #endregion
       
    }
}