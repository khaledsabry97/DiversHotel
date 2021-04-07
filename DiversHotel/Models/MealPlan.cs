using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiversHotel.Models
{
  public class MealPlan
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public String Id { get; set; }

    public String MealPlanType { get; set; }
    
  }

  
  public class MealPlanPrice
  {
    public MealPlan MealPlanType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
  }
  public enum MealPlanType
  {
    HalfBoard,
    FullBoard,
    AllInclusive
  }
}