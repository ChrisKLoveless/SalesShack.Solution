using System.ComponentModel.DataAnnotations;

namespace SalesShack.Models
{
  public class Client 
  {
    public int ClientId { get; set; }

    public string Name { get; set; }

    public string Company { get; set; }
    [Required(ErrorMessage = "The phone number field can't be empty!")]
    public string PhoneNumber { get; set; }
  }    
}