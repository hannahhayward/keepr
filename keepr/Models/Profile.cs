using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Profile
  {
    public string Id {get; set;}
    [Required]
    public string Name {get;set;}
    public string Picture {get;set;}
  }
}