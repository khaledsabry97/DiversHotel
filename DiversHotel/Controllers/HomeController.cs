using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.Repositories;
using DiversHotel.Functionality;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiversHotel.Models;
using DiversHotel.ViewModels;

namespace DiversHotel.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly MealPlanRepository _mealPlanRepository;
    private readonly RoomRepository _roomRepository;
    private readonly ReservationRepository _reservationRepository;
    private readonly MealPlanPricesRepository _mealPlanPricesRepository;
    private readonly RoomPricesRepository _roomPricesRepository;

    public HomeController(ILogger<HomeController> logger
      , MealPlanRepository mealPlanRepository,
      RoomRepository roomRepository,
      ReservationRepository reservationRepository,
      MealPlanPricesRepository mealPlanPricesRepository,
      RoomPricesRepository roomPricesRepository)
    {
      _logger = logger;
      _mealPlanRepository = mealPlanRepository;
      _roomRepository = roomRepository;
      _reservationRepository = reservationRepository;
      _mealPlanPricesRepository = mealPlanPricesRepository;
      _roomPricesRepository = roomPricesRepository;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
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
    public async Task<IActionResult> Book(BookViewModel bookViewModel,CancellationToken cancellationToken)
    {
      if (!ModelState.IsValid)
        return View(bookViewModel);

      if (bookViewModel.CheckIn > bookViewModel.CheckOut || bookViewModel.CheckIn < DateTime.Today)
      {
        ModelState.AddModelError("","Please select right Duration");
      }
      
      
      
      Booking booking = new Booking(_reservationRepository,_roomRepository,_roomPricesRepository,_mealPlanRepository,_mealPlanPricesRepository);
      
      //get No Of Needed Rooms
      int neededRooms = booking.calculateNoOfRooms(bookViewModel.NoOfAdults, bookViewModel.NoOfChildren);
      
      //get free Rooms
      List<Room> rooms = await booking.getFreeRooms(bookViewModel.RoomTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, cancellationToken);

      if (rooms.Count < neededRooms)
      {
        ModelState.AddModelError("","No Free Room in the hotel having {0}"+bookViewModel.RoomTypeSelected+"in this duration");
        return View(bookViewModel);
      }
      
      //calculate Meal Cost
      int MealCost = booking.calculateMealPrice(bookViewModel.MealTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, bookViewModel.NoOfAdults + bookViewModel.NoOfChildren);
      
      
      //calculate RoomCost
      int RoomCost = booking.calculateRoomPrice(bookViewModel.RoomTypeSelected, bookViewModel.CheckIn,
        bookViewModel.CheckOut, neededRooms);

      //calculate Total cost
      int TotalCost = MealCost + RoomCost;

      ReservationViewModel reservationViewModel = new ReservationViewModel
      {
        Name = bookViewModel.Name,
        Email = bookViewModel.Email,
        CheckIn = bookViewModel.CheckIn,
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



      return RedirectToAction("GetReservation",reservationViewModel);
    }

    [HttpGet]
    public IActionResult GetReservation(ReservationViewModel reservationViewModel)
    {
      return View(reservationViewModel);
    }
    
    
    [HttpPost]
    public IActionResult Reservation(ReservationViewModel reservationViewModel)
    {
      return View(reservationViewModel);
    }
    
    
    
    
    
  }
}