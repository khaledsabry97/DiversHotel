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
  }
}