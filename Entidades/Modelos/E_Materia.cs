using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
  public class E_Materia
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMateria { get; set; }

    [Required(ErrorMessage = "Debe capturar la clave")]
    [StringLength(6)]
    public string ClaveMateria { get; set; }

    [Required(ErrorMessage = "Debe capturar el nombre de la materia")]
    [StringLength(250)]
    public string NombreMateria { get; set; }

    public int IdCarrera { get; set; }
    [ForeignKey("IdCarrera")]
    public virtual E_Carrera Carreras { get; set; }
  }
}
