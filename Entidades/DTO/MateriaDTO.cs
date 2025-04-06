using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
  public class MateriaDTO
  {
    public int IdMateria { get; set; }
    public string ClaveMateria { get; set; }
    public string NombreMateria { get; set; }
    public int IdCarrera { get; set; }
  }
}
