using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task.Models;
using task.Data; // AppDbContext üçün lazımdır

namespace task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context; // Baza ilə əlaqə üçün dəyişən

    // Constructor vasitəsilə həm Logger-i, həm də AppDbContext-i qəbul edirik
    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

   [HttpPost]
[IgnoreAntiforgeryToken] // JavaScript-dən gələn sorğularda problem çıxmaması üçün
public IActionResult Reserve([FromBody] TaskItem booking)
{
    if (booking != null)
    {
        _context.Tasks.Add(booking);
        _context.SaveChanges();
        return Ok();
    }
    return BadRequest();
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}