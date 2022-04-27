#nullable disable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dotnet.Models;

namespace Dotnet.Controllers;

public class ProdutosController : Controller
{
    private readonly Contexto _context;

    public ProdutosController(Contexto context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        Produtos produto=new Produtos();
        produto.Id=1;
        produto.Nome="SJSksj";
        
        return View(await _context.Produtos.ToListAsync());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
