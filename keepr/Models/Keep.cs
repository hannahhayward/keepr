using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
{
  public int Id {get; set;}
  public string CreatorId {get;set;}
  [Required]
  public string Name {get;set;}
  public string Description {get;set;}
  public string ImgUrl {get;set;}
  public int Views {get;set;}
  public int Shares {get;set;}
  public Profile Creator {get;set;}
}
}