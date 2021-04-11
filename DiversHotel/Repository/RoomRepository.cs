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
  public class RoomRepository : Repository<Room>
  {
    public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Room> GetAllRooms()
    {
      IEnumerable<Room> rooms = TableNoTracking.ToArray();


      return rooms;
    }

/// <summary>
/// get free rooms after excluding booked rooms
/// </summary>
/// <param name="bookedRoomsIds"></param>
/// <param name="roomType"></param>
/// <param name="cancellationToken"></param>
/// <returns></returns>
    public async Task<List<Room>> GetFreeRooms(List<String> bookedRoomsIds,RoomType roomType,CancellationToken cancellationToken)
    {
      List<Room> rooms = await Table.Where(e => e.RoomType == roomType).ToListAsync(cancellationToken);
      List<Room> freeRooms = new List<Room>();
      foreach (var room in rooms)
      {
        bool found = false;
        foreach (var bookedRoomsId in bookedRoomsIds)
        {
          if (room.Id == bookedRoomsId)
          {
            found = true;
            break;
          }
          
        }
        if (!found)
        {
          freeRooms.Add(room);
        }
      }

      return freeRooms;
    }


    
  }
}