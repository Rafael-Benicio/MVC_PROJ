using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dotnet.Models;

namespace Dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult Produtos()
    // {
    //     Produtos produto=new Produtos();
    //     produto.Id=1;
    //     produto.Nome="Rafael";
        
    //     return View(produto);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
