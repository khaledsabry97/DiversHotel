using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiversHotel.Data;
using DiversHotel.Models;

namespace Data.Repositories
{
  public class MealPlanPricesRepository : Repository<MealPlanPrice>
  {
    public MealPlanPricesRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<MealPlanPrice> GetAllMealPlansPrices()
    {
      IEnumerable<MealPlanPrice> mealPlanPrices = TableNoTracking.ToArray();


      return mealPlanPrices;
    }
    
  }
}