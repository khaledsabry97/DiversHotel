using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiversHotel.ViewModels
{
  public class BookViewModel
  {
    [Display(Description = "Enter Your Name")]
    [Required]
    public String Name { get; set; }

    [Display(Description = "Enter Your Email")]
    [Required]
    public String Email { get; set; }

    public String Country { get; set; }

    [Display(Name = "No. Of Adults")]
    [Required]
    [Range(1,100)]
    public int NoOfAdults { get; set; }

    [Display(Name = "No. Of Children")]
    [Required]
    [Range(0,100)]
    public int NoOfChildren { get; set; }

    [Display(Name = "Room Type")]
    [Required]
    public String RoomTypeSelected { get; set; }
    public List<String> RoomType { get; set; } = new List<string>();

    [Display(Name = "Meal Type")]
    [Required]
    public String MealTypeSelected { get; set; }
    public List<String> MealPlan { get; set; } = new List<string>();


    [Required]
    public DateTime CheckIn { get; set; }

    [Required]
    public DateTime CheckOut { get; set; }
  }
}