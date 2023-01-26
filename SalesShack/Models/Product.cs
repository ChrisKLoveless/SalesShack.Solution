using System.ComponentModel.DataAnnotations;

namespace SalesShack.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The product name field can't be empty!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Sale> Sales { get; set; }

        public List<Promotion> Promotions { get; set; }
    }
}