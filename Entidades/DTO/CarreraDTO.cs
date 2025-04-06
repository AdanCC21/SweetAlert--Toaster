using Entidades.Modelos;
using System.ComponentModel.DataAnnotations;

namespace Entidades.DTO
{
  public class CarreraDTO
  {
    public int IdCarrera { get; set; }

    [Required(ErrorMessage = "Debe capturar la clave.")]
    public string ClaveCarrera { get; set; }

    [Required(ErrorMessage = "Debe capturar el nombre.")]
    public string NombreCarrera { get; set; }

    [Required(ErrorMessage = "Debe capturar el Alias.")]
    public string AliasCarrera { get; set; }

    public bool EstadoCarrera { get; set; }
  }
}
