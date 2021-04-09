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
  public class RoomPricesRepository : Repository<RoomPrice>
  {
    public RoomPricesRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    
    public IEnumerable<RoomPrice> GetAllRoomPrices()
    {
      IEnumerable<RoomPrice> roomPrices = TableNoTracking.ToArray();


      return roomPrices;
    }

    
    public RoomPrice GetRoomPrice(RoomType roomType,DateTime dateTime)
    {
      RoomPrice roomPrice = TableNoTracking.First(e =>
        e.StartDate <= dateTime && e.EndDate >= dateTime && e.RoomType == roomType);

      return roomPrice;
    }
    
  }
}