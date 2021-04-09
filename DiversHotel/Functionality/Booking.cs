using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data.Repositories;
using DiversHotel.Models;

namespace DiversHotel.Functionality
{
  public class Booking
  {
    private readonly ReservationRepository _reservationRepository;
    private readonly RoomRepository _roomRepository;
    private readonly RoomPricesRepository _roomPricesRepository;
    private readonly MealPlanRepository _mealPlanRepository;
    private readonly MealPlanPricesRepository _mealPlanPricesRepository;

    public Booking(ReservationRepository reservationRepository, RoomRepository roomRepository,RoomPricesRepository roomPricesRepository,MealPlanRepository mealPlanRepository,MealPlanPricesRepository mealPlanPricesRepository)
    {
      _reservationRepository = reservationRepository;
      _roomRepository = roomRepository;
      _roomPricesRepository = roomPricesRepository;
      _mealPlanRepository = mealPlanRepository;
      _mealPlanPricesRepository = mealPlanPricesRepository;
    }

    public int calculateNoOfRooms(int adults, int childrens)
    {

      int bigger = childrens;
      if (adults > childrens)
        bigger = adults;
      
      int rooms = bigger/2;
      if (adults % 2 == 1)
        rooms++;

      return rooms;
    }


    public async Task<List<Room>> getFreeRooms(String roomTypeSelected,DateTime checkIn,DateTime checkOut, CancellationToken cancellationToken)
    {
      RoomType roomType = Booking.converToEnum<RoomType>(roomTypeSelected);
      List<String> bookedroomsIDs = await _reservationRepository.GetAllBookedRooms(checkIn, checkOut,
        roomType, cancellationToken);

     List<Room> rooms = await _roomRepository.GetFreeRooms(bookedroomsIDs, roomType, cancellationToken);
     return rooms;
    }


    public int calculateMealPrice(String MealType, DateTime checkIn, DateTime checkOut,int NoOfPersons)
    {

      MealPlan mealPlan = _mealPlanRepository.GetMealPlanByName(MealType);
      DateTime tempDate = checkIn;
      MealPlanPrice mealPlanPrice = _mealPlanPricesRepository.GetMealPlanPrice(mealPlan.Id, tempDate);

      int cost = 0;

      while (checkOut >= tempDate)
      {
        if (mealPlanPrice.EndDate < tempDate)
          mealPlanPrice = _mealPlanPricesRepository.GetMealPlanPrice(mealPlan.Id, tempDate);
        cost += mealPlanPrice.Price;
        tempDate = tempDate.AddDays(1);
      }

      cost = cost * NoOfPersons;

      return cost;
    }
    
    public int calculateRoomPrice(String RoomType, DateTime checkIn, DateTime checkOut,int NoOfRooms)
    {

      RoomType roomType = Booking.converToEnum<RoomType>(RoomType);
      DateTime tempDate = checkIn;
      RoomPrice roomPrice = _roomPricesRepository.GetRoomPrice(roomType, tempDate);

      int cost = 0;

      while (checkOut >= tempDate)
      {
        if (roomPrice.EndDate < tempDate)
          roomPrice = _roomPricesRepository.GetRoomPrice(roomType, tempDate);
        cost += roomPrice.Price;
        tempDate = tempDate.AddDays(1);
      }

      cost = cost * NoOfRooms;

      return cost;
    }
    
    
    public static EnumType converToEnum<EnumType>(String enumValue)  
    {
      return (EnumType) Enum.Parse(typeof(EnumType), enumValue);
    }
  }
}