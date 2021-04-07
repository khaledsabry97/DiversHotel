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


    
  }
}