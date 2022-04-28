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
    // Obtem os valores do baconde dados passados por "Contexto"
    private readonly Contexto _context;

    // Construtor da classe ProdutosController
    public ProdutosController(Contexto context)
    {
        _context = context;
    }
    // O nome do método é uma forma de apontar para o arquivo '.cshtml' que é desejado retornar
    public async Task<IActionResult> Index()
    {   
        // 'return View()' manda o arquivo '.cshtml' para a rota e o parametro de view é 
        // um valor passivel de ser utilizado no front
        return View(await _context.Produtos.ToListAsync());
    }

    public IActionResult Create()
    {   
        return View();
    }
    
    public async Task<IActionResult> Edit(int? id)
    {   
        // Trata o valor de id pra ver se ele não é nulo
        if (id == null)
        {
            return NotFound();
        }
        // Armazena em produto o primeiro registro que for encontrado
        // com valor correspondente ao e ID
        var produtos = await _context.Produtos
            .FirstOrDefaultAsync(m => m.Id == id);
        // Checar o valor retornado para produtos não é nulo
        if (produtos == null)
        {
            return NotFound();
        }
        // rotorna o registro encontrado na tabela do banco
        return View(produtos);
    }

    // Vai apontar para uma rota 
    // Produtos/Delete/id_do_protudo
    public async Task<IActionResult> Delete(int? id)
    {   
        // Trata o valor de id pra ver se ele não é nulo
        if (id == null)
        {
            return NotFound();
        }
        // Armazena em produto o primeiro registro que for encontrado
        // com valor correspondente ao e ID
        var produtos = await _context.Produtos
            .FirstOrDefaultAsync(m => m.Id == id);
        // Checar o valor retornado para produtos não é nulo
        if (produtos == null)
        {
            return NotFound();
        }
        // rotorna o registro encontrado na tabela do banco
        return View(produtos);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id,[Bind("Id,Name,Description")] Produtos produto)
    {
        if (produto.Id != id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!ProdutosExists(produto.Id))
                // {
                //     return NotFound();
                // }
                // else
                // {
                    throw;
                // }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }

    // POST: Produtos/Delete/5
    // Quando o butão submit do formulario for clicado
    // Os dados serão mandado para cá, por ambos os Actions serem 'Delete'
    [HttpPost, ActionName("Delete")]
    // É um método que gera e insere no HTML 
    // gerado na view um código para evitar 
    // que se falsifique o envio de dados para o servidor.
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // Encontra o registro no bd
        var produto = await _context.Produtos.FindAsync(id);
        // Deleta do bd o registro com o id correspondente
        _context.Produtos.Remove(produto);
        // Salva as alterações
        await _context.SaveChangesAsync();
        // Redireciona para a tela retornada pelo método Index
        return RedirectToAction(nameof(Index));
    }

  

    [HttpPost]
    [ValidateAntiForgeryToken]
    // O Parametro passado serve para injetar na variavel de tipo Produto, os valores de Id e Nome
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] Produtos produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
