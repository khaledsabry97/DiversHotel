using System;
using System.Collections.Generic;

namespace DiversHotel.ViewModels
{
  public class BookViewModel
  {

    public String Name { get; set; }
    public String Email { get; set; }
    public String Country { get; set; }
    
    public int NoOfAdults { get; set; }
    public int NoOfChildren { get; set; }
    
    public List<String> RoomType{ get; set; } = new List<string>();

    public List<String> MealPlan{ get; set; } = new List<string>();



    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
  }
}