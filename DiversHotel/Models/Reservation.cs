using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiversHotel.Models
{
  public class Reservation
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public String Id { get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();

    // public String GuestId { get; set; }
    public Guest Guest { get; set; }

    // public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; }
    public RoomType RoomType { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int Price { get; set; }
  }
}