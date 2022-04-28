using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dotnet.Models;
[Table("Produtos")]
public class Produtos
{
    [Column("Id")]
    [Display(Name="Code")]
    public int Id { get; set; }
    [Column("Name")]
    [Display(Name="Name")]
    public string Name { get; set; }
    [Column("Description")]
    [Display(Name="Description")]
    public string Description { get; set; }

}