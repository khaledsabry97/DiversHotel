using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiversHotel.Data;
using DiversHotel.Models;

namespace Data.Repositories
{
  public class MealPlanRepository : Repository<MealPlan>
  {
    public MealPlanRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


    public List<MealPlan> GetAllMealPlans()
    {
      List<MealPlan> mealPlans = TableNoTracking.ToList();


      return mealPlans;
    }

    public MealPlan GetMealPlanByName(String Name)
    {
      MealPlan mealPlan = TableNoTracking.First(e => e.MealPlanType == Name);
      return mealPlan;
    }
  }
}