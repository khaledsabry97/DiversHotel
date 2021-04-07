using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiversHotel.Models
{
  public class Reservation
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public String Id { get; set; }
    public Room Room { get; set; }
    public Guest Guest { get; set; }
    public MealPlan MealPlan { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int Price { get; set; }
  }
}