using System.ComponentModel.DataAnnotations;

namespace SalesShack.Models
{
  public class Promotion
  {
    public int PromotionId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    [Required(ErrorMessage = "The product field can't be empty!")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
  }
}