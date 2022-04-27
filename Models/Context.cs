using Microsoft.EntityFrameworkCore;

namespace Dotnet.Models;

public class Contexto:DbContext
{
    public Contexto(DbContextOptions<Contexto> options):base(options)
    {

    }
    public DbSet<Produtos> Produtos {get;set;}
}
