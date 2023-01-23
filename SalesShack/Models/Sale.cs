using System.ComponentModel.DataAnnotations;

namespace SalesShack.Models 
{
  public class Sale 
  {
    public int SaleId { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public DateTime? DateSold { get; set; }

    public User User { get; set; }
    [Required(ErrorMessage = "The product field can't be empty!")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
  }
}