using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiversHotel.Models
{
  public class Room
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public String Id { get; set; }

    public RoomType RoomType { get; set; }

    
  }
  


  public class RoomPrice
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public RoomType RoomType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }
  }

  public enum RoomType
  {
    SeaView,
    PoolView,
    GardenView,
    StandardView
  }
  
}