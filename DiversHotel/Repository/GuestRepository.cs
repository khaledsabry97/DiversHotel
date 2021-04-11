using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DiversHotel.Data;
using DiversHotel.Models;

namespace Data.Repositories
{
  public class GuestRepository : Repository<Guest>
  {
    public GuestRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<IEnumerable<Guest>> GetAll(CancellationToken cancellationToken, int range = 20)
    {
      List<Guest> guests = await Table
        .Take(range)
        .ToListAsync(cancellationToken);

      return guests;
    }
  }
}