using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Data.Repositories;
using DiversHotel.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DiversHotel.Models
{
  
  public class DbInitializer
  {
    public static void Seed(IServiceProvider serviceProvider)
    {

      #region Room
      RoomRepository roomRepository =
        serviceProvider.GetRequiredService<RoomRepository>();

      if (!roomRepository.GetAllRooms().Any())
      {
        roomRepository.AddRange(DbInitializer.GetRooms());
      }
      

      #endregion

      #region RoomPrices

      RoomPricesRepository roomPricesRepository =
        serviceProvider.GetRequiredService<RoomPricesRepository>();
      
      if (!roomPricesRepository.GetAllRoomPrices().Any())
      {
        roomPricesRepository.AddRange(DbInitializer.getRoomPrices());
      }

      #endregion

      #region MealPlan

      MealPlanRepository mealPlanRepository =
        serviceProvider.GetRequiredService<MealPlanRepository>();

      if (!mealPlanRepository.GetAllMealPlans().Any())
      {
        mealPlanRepository.AddRange(DbInitializer.getMealPlans());
      }

      #endregion

      #region MealPlanPrices

      MealPlanPricesRepository mealPlanPricesRepository =
        serviceProvider.GetRequiredService<MealPlanPricesRepository>();

      if (!mealPlanPricesRepository.GetAllMealPlansPrices().Any())
      {
        mealPlanPricesRepository.AddRange(DbInitializer.getMealPlanPrices());
      }

      #endregion
      
   
      
      
      
    }

    private static IEnumerable<Room> GetRooms()
    {
      IEnumerable<RoomType> roomTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();
      List<Room> rooms = new List<Room>();
      while (rooms.Count()!= 150)
      {
        foreach (var roomType in roomTypes)
        {
          Room room = new Room
          {
            RoomType = roomType
          };
          rooms.Add(room);
          if (rooms.Count() == 150)
            break;
        }
      }

      return rooms;
    }
    
    
    private static IEnumerable<RoomPrice> getRoomPrices()
    {
      List<RoomPrice> roomPrices = new List<RoomPrice>()
      {
        new RoomPrice()
        {
          RoomType = RoomType.StandardView,
          StartDate = new DateTime(2021, 1, 1),
          EndDate = new DateTime(2021, 1, 15),
          Price = 80
        },
        new RoomPrice()
        {
          RoomType = RoomType.StandardView,
          StartDate = new DateTime(2021, 1, 16),
          EndDate = new DateTime(2021, 4, 30),
          Price = 50
        },
        new RoomPrice()
        {
          RoomType = RoomType.SeaView,
          StartDate = new DateTime(2021, 1, 1),
          EndDate = new DateTime(2021, 1, 15),
          Price = 120
        },
        new RoomPrice()
        {
          RoomType = RoomType.SeaView,
          StartDate = new DateTime(2021, 1, 16),
          EndDate = new DateTime(2021, 3, 31),
          Price = 90
        },
        new RoomPrice()
        {
          RoomType = RoomType.SeaView,
          StartDate = new DateTime(2021, 4, 1),
          EndDate = new DateTime(2021, 4, 30),
          Price = 100
        },
        new RoomPrice()
        {
          RoomType = RoomType.PoolView,
          StartDate = new DateTime(2021, 4, 1),
          EndDate = new DateTime(2021, 4, 15),
          Price = 100
        }
        ,
        new RoomPrice()
        {
          RoomType = RoomType.PoolView,
          StartDate = new DateTime(2021, 4, 16),
          EndDate = new DateTime(2021, 4, 30),
          Price = 150
        }

      };

      return roomPrices;
    }
    
    private static IEnumerable<MealPlan> getMealPlans()
    {
      List<MealPlan> mealPlans = new List<MealPlan>()
      {
        new MealPlan()
        {
          MealPlanType= "Half Board"
        },
        new MealPlan()
        {
          MealPlanType= "Full Board"
        },
        new MealPlan()
        {
          MealPlanType= "All Inclusive"
        },

      };

      return mealPlans;
    }
    
    
    private static IEnumerable<MealPlanPrice> getMealPlanPrices()
    {
      List<MealPlanPrice> mealPlanPrices = new List<MealPlanPrice>()
      {
        new MealPlanPrice()
        {
          MealPlanId = 1,
          StartDate = new DateTime(2021, 1, 1),
          EndDate = new DateTime(2021, 5, 30),
          Price= 5
        },
        new MealPlanPrice()
        {
          MealPlanId = 1,
          StartDate = new DateTime(2021, 6, 1),
          EndDate = new DateTime(2021, 12, 31),
          Price= 10
        },
        new MealPlanPrice()
        {
          MealPlanId = 2,
          StartDate = new DateTime(2021, 1, 1),
          EndDate = new DateTime(2021, 5, 30),
          Price= 20
        },
        new MealPlanPrice()
        {
          MealPlanId = 2,
          StartDate = new DateTime(2021, 6, 1),
          EndDate = new DateTime(2021, 12, 31),
          Price= 25
        },
        new MealPlanPrice()
        {
          MealPlanId = 3,
          StartDate = new DateTime(2021, 1, 1),
          EndDate = new DateTime(2021, 5, 30),
          Price= 25
        },
        new MealPlanPrice()
        {
          MealPlanId = 3,
          StartDate = new DateTime(2021, 6, 1),
          EndDate = new DateTime(2021, 12, 31),
          Price= 30
        }
      };

      return mealPlanPrices;
    }
    
  }
}