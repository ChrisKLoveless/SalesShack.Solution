using System.ComponentModel.DataAnnotations;

namespace SalesShack.Models 
{
  public class Sale 
  {
    public int SaleId { get; set; }
    public int Price { get; set; }
    public DateOnly? DateSold { get; set; }
    public int UserId { get; set; }
    public List<ProductSale> JoinEntities { get; set; }
  }
}