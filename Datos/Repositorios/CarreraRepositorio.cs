using Datos.Contexto;
using Datos.IRepositorios;
using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Datos.Repositorios
{
   /// <summary>
   /// Implementación concreta del repositorio para la gestión de carreras
   /// </summary>
   /// <remarks>
   /// Proporciona operaciones CRUD para la entidad E_Carrera utilizando Entity Framework Core
   /// como ORM para interactuar con la base de datos.
   /// </remarks>
   public class CarreraRepositorio(D_ContextoBD contextoBD) : ICarreraRepositorio
   {
      private readonly D_ContextoBD _contextoBD = contextoBD;

      /// <summary>
      /// Inserta una nueva carrera en la base de datos
      /// </summary>
      /// <param name="carrera">Entidad de carrera a insertar</param>
      /// <returns>Tarea asincrónica</returns>
      /// <exception cref="DbUpdateException">Error al guardar cambios en la base de datos por ejemplo violación de la llave primaria, Llave única, etc.</exception>
      public async Task InsertarCarrera(E_Carrera carrera)
      {
         try
         {
            await _contextoBD.Carreras.AddAsync(carrera);
            await _contextoBD.SaveChangesAsync();
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Elimina una carrera existente de la base de datos
      /// </summary>
      /// <param name="idCarrera">Identificador único de la carrera</param>
      /// <returns>Tarea asincrónica</returns>
      /// <exception cref="KeyNotFoundException">Si no existe la carrera con el ID especificado o s está usando en otra tabla</exception>
      public async Task BorrarCarrera(int idCarrera)
      {
         var carreraBD = await _contextoBD.Carreras.FindAsync(idCarrera);
         if (carreraBD == null)
            throw new KeyNotFoundException($"Carrera con ID {idCarrera} no encontrada");

         _contextoBD.Remove(carreraBD);
         await _contextoBD.SaveChangesAsync();
      }

      /// <summary>
      /// Actualiza los datos de una carrera existente
      /// </summary>
      /// <param name="carrera">Entidad de carrera con datos actualizados</param>
      /// <returns>Tarea asincrónica</returns>
      /// <exception cref="KeyNotFoundException">Si no existe la carrera con el ID especificado</exception>
      public async Task ModificarCarrera(E_Carrera carrera)
      {
         var existente = await BuscarCarrera(carrera.IdCarrera);
         if (existente == null)
            throw new KeyNotFoundException($"Carrera con ID {carrera.IdCarrera} no encontrada");

         _contextoBD.Carreras.Update(carrera);
         await _contextoBD.SaveChangesAsync();
      }

      /// <summary>
      /// Obtiene todas las carreras registradas
      /// </summary>
      /// <returns>Listado enumerable de carreras</returns>
      public async Task<IEnumerable<E_Carrera>> ListarCarreras()
      {
         return await _contextoBD.Carreras.ToListAsync();
      }

      /// <summary>
      /// Obtiene carreras filtradas por criterio de búsqueda
      /// </summary>
      /// <param name="criterioBusqueda">Texto para filtrar (opcional)</param>
      /// <returns>Listado enumerable de carreras que coinciden con el criterio</returns>
      /// <remarks>
      /// La búsqueda se realiza sobre los campos ClaveCarrera, NombreCarrera y AliasCarrera
      /// utilizando comparación parcial (LIKE) case-sensitive
      /// </remarks>
      public async Task<IEnumerable<E_Carrera>> ListarCarreras(string criterioBusqueda = null)
      {
         var query = _contextoBD.Carreras.AsQueryable();

         if (!string.IsNullOrWhiteSpace(criterioBusqueda))
         {
            query = query.Where(c =>
                c.ClaveCarrera.Contains(criterioBusqueda) ||
                c.NombreCarrera.Contains(criterioBusqueda) ||
                c.AliasCarrera.Contains(criterioBusqueda)
            );
         }

         return await query.ToListAsync();
      }

      /// <summary>
      /// Busca una carrera por su identificador único
      /// </summary>
      /// <param name="idCarrera">ID de la carrera a buscar</param>
      /// <returns>Entidad de carrera encontrada o null</returns>
      public async Task<E_Carrera> BuscarCarrera(int idCarrera)
      {
         return await _contextoBD.Carreras.FindAsync(idCarrera);
      }
   }
}