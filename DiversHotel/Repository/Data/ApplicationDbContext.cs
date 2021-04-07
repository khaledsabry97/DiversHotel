using DiversHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace DiversHotel.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<RoomPrice>(builder => builder.ToTable("RoomPrices").HasNoKey());
      modelBuilder.Entity<Room>(builder => builder.ToTable("Rooms"));
      modelBuilder.Entity<Guest>(builder => builder.ToTable("Guests"));
      modelBuilder.Entity<MealPlan>(builder => builder.ToTable("MealPlans"));
      modelBuilder.Entity<MealPlanPrice>(builder => builder.ToTable("MealPlanPrices").HasNoKey());
      modelBuilder.Entity<Reservation>(builder => builder.ToTable("Reservations"));
      


    }

    
  }
}