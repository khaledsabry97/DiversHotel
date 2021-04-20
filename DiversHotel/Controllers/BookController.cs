using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Repositories;
using DiversHotel.Functionality;
using DiversHotel.Models;
using DiversHotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiversHotel.Controllers
{
  public class BookController : Controller
  {
    private readonly MealPlanRepository _mealPlanRepository;
    private readonly Booking _booking;

    public BookController(MealPlanRepository mealPlanRepository,
      Booking booking)
    {
      _mealPlanRepository = mealPlanRepository;
      _booking = booking;
    }


    [HttpGet]
    public IActionResult Book()
    {
      List<MealPlan> mealPlans = _mealPlanRepository.GetAllMealPlans();
      List<RoomType> Types = Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToList();
      List<String> roomTypes = new List<string>();
      foreach (var type in Types)
      {
        roomTypes.Add(Enum.GetName(type.GetType(), type));
      }

      BookViewModel bookViewModel = new BookViewModel();
      foreach (var mealPlan in mealPlans)
      {
        bookViewModel.MealPlan.Add(mealPlan.MealPlanType);
      }

      bookViewModel.RoomType = roomTypes;
      bookViewModel.CheckIn = DateTime.Today;
      bookViewModel.CheckOut = DateTime.Today.Add(TimeSpan.FromDays(7));
      return View(bookViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> Book(BookViewModel bookViewModel, CancellationToken cancellationToken)
    {
      if (!ModelState.IsValid)
        return View(bookViewModel);

      if (bookViewModel.CheckIn > bookViewModel.CheckOut || bookViewModel.CheckIn < DateTime.Today)
      {
        ModelState.AddModelError("", "Please select right Duration");
      }


      //get No Of Needed Rooms
      int neededRooms = _booking.calculateNoOfRooms(bookViewModel.NoOfAdults, bookViewModel.NoOfChildren);

      //get free Rooms
      List<Room> rooms = await _booking.getFreeRooms(bookViewModel.RoomTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, cancellationToken);

      if (rooms.Count < neededRooms)
      {
        ModelState.AddModelError("",
          "No Free Room in the hotel having " + bookViewModel.RoomTypeSelected + " in this duration");
        return View(bookViewModel);
      }

      //calculate Meal Cost
      int MealCost = _booking.calculateMealPrice(bookViewModel.MealTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, bookViewModel.NoOfAdults + bookViewModel.NoOfChildren);


      //calculate RoomCost
      int RoomCost = _booking.calculateRoomPrice(bookViewModel.RoomTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, neededRooms);

      //calculate Total cost
      int TotalCost = MealCost + RoomCost;


      if (ModelState.ErrorCount > 0)
        return View(bookViewModel);


      ReservationViewModel reservationViewModel = new ReservationViewModel
      {
        Name = bookViewModel.Name,
        Email = bookViewModel.Email,
        Country = bookViewModel.Country,
        CheckIn = bookViewModel.CheckIn ,
        CheckOut = bookViewModel.CheckOut,
        RoomType = bookViewModel.RoomTypeSelected,
        MealType = bookViewModel.MealTypeSelected,
        NoOfAdults = bookViewModel.NoOfAdults,
        NoOfChildren = bookViewModel.NoOfChildren,
        NoOfRooms = neededRooms,
        MealCost = MealCost,
        RoomCost = RoomCost,
        TotalCost = TotalCost
      };


      return RedirectToAction("GetReservation", reservationViewModel);
    }

    [HttpGet]
    public IActionResult GetReservation(ReservationViewModel reservationViewModel)
    {
      return View(reservationViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> PostReservation(ReservationViewModel reservationViewModel,DateTime CheckIn,DateTime CheckOut,CancellationToken cancellationToken)
    {
      Reservation reservation = await _booking.Reserve(reservationViewModel.Name, reservationViewModel.Email,
        reservationViewModel.Country,
        reservationViewModel.NoOfRooms, reservationViewModel.RoomType, reservationViewModel.MealType, 
        reservationViewModel.CheckIn, reservationViewModel.CheckOut, reservationViewModel.TotalCost, cancellationToken);

      foreach (var room in reservation.Rooms)
      {
        reservationViewModel.RoomIds.Add(room.Id);
      }

      reservationViewModel.ReservationId = reservation.Id;

      return RedirectToAction("Reservation", reservationViewModel);
    }


    [HttpGet]
    public IActionResult Reservation(ReservationViewModel reservationViewModel)
    {
      return View(reservationViewModel);
    }
  }
}