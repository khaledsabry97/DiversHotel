using Microsoft.EntityFrameworkCore;

namespace DiversHotel.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
  }
}