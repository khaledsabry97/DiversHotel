using System;
using System.ComponentModel.DataAnnotations;

namespace DiversHotel.ViewModels
{
  public class ReservationViewModel
  {
    public String Name { get; set; }
    public String Email { get; set; }
    [Display(Name = "Check In")] public DateTime CheckIn { get; set; }
    [Display(Name = "Check Out")] public DateTime CheckOut { get; set; }
    [Display(Name = "No of Adults")] public int NoOfAdults { get; set; }
    [Display(Name = "No of Children")] public int NoOfChildren { get; set; }
    [Display(Name = "Room View")] public String RoomType { get; set; }
    [Display(Name = "Meal Type")] public String MealType { get; set; }
    [Display(Name = "No of Rooms")] public int NoOfRooms { get; set; }
    [Display(Name = "Cost of Rooms")] public int RoomCost { get; set; }
    [Display(Name = "Cost of Meals")] public int MealCost { get; set; }
    [Display(Name = "Total Cost")] public int TotalCost { get; set; }
  }
}