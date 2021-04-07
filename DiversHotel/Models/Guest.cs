using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DiversHotel.Models
{
  public class Guest
  {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public String Id { get; set; }

    [Required]
    public String Name { get; set; }

    [EmailAddress]
    public String Email { get; set; }
  }
}