using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
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

    public HomeController(ILogger<HomeController> logger
      , MealPlanRepository mealPlanRepository,
      RoomRepository roomRepository)
    {
      _logger = logger;
      _mealPlanRepository = mealPlanRepository;
      _roomRepository = roomRepository;
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
      List<String> roomTypes = Enum.GetValues(typeof(RoomType)).Cast<String>().ToList();

      BookViewModel bookViewModel = new BookViewModel();
      foreach (var mealPlan in mealPlans)
      {
        bookViewModel.MealPlan.Add(mealPlan.MealPlanType);
      }

      bookViewModel.RoomType = roomTypes;
      bookViewModel.CheckIn = DateTime.Today;
      bookViewModel.CheckOut = DateTime.Today.Add(TimeSpan.FromDays(7));
      return View();
    }


    [HttpPost]
    public IActionResult Book(BookViewModel bookViewModel)
    {
      if (!ModelState.IsValid)
        return View(bookViewModel);


      return RedirectToAction("Reservation");
    }

    [HttpGet]
    public IActionResult Reservation()
    {
      return View();
    }
  }
}