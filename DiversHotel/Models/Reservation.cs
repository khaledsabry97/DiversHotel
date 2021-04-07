using System;

namespace DiversHotel.Models
{
  public class Reservation
  {
    public Room Room { get; set; }
    public Guest Guest { get; set; }
    public MealPlanType MealPlanType { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int Price { get; set; }
  }
}