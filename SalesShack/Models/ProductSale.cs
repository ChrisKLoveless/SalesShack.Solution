namespace SalesShack.Models
{
  public class ProductSale
  {
    public int ProductSaleId { get; set; }
    public int SaleId { get; set; }
    public Sale Sale { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
  }
}