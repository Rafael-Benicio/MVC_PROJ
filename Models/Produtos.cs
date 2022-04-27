using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dotnet.Models;
[Table("Produto")]
public class Produtos
{
    [Column("Id")]
    [Display(Name="Código")]
    public int Id { get; set; }
    [Column("Nome")]
    [StringLength(20)]
    [Display(Name="Nome")]
    public string Nome { get; set; }

}