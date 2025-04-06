using Microsoft.EntityFrameworkCore;

using Entidades.DTO;
using Entidades.Modelos;

namespace Datos.Contexto
{
  public class D_ContextoBD : DbContext
  {
    public D_ContextoBD(DbContextOptions<D_ContextoBD> options) : base(options)
    {
    }
    public DbSet<E_Carrera> Carreras { get; set; }
    public DbSet<E_Materia> Materias { get; set; }
  }
}
