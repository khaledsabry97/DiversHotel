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
  public class ReservationRepository : Repository<Reservation>
  {
    public ReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<IEnumerable<Reservation>> GetAll(CancellationToken cancellationToken, int range = 20)
    {
      List<Reservation> reservations = await TableNoTracking
        .Take(range)
        .ToListAsync(cancellationToken);

      return reservations;
    }


    /// <summary>
    /// get all booked rooms in range of date
    /// </summary>
    /// <param name="Start_Date"></param>
    /// <param name="End_Date"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Ids of rooms booked in that range</returns>
    public async Task<List<string>> GetAllBookedRooms(DateTime Start_Date, DateTime End_Date,RoomType roomType,CancellationToken cancellationToken)
    {
      List<Reservation> reservations = await Table.Include(e=>e.Rooms)
        .Where(e => e.EndDate > Start_Date && e.StartDate < End_Date && e.RoomType == roomType).ToListAsync(cancellationToken);

      List<String> roomIds = new List<string>();
      foreach (var reservation in reservations)
      {
        foreach (var room in reservation.Rooms)
        {
          roomIds.Add(room.Id);

        }
      }

      return roomIds;
    }
    
    
    
  }
}