using Entidades.DTO;
using Entidades.Modelos;

namespace Datos.IRepositorios
{
   /// <summary>
   /// Interfaz que define el contrato para el repositorio de gestión de carreras 
   /// </summary>
   /// <remarks>
   /// Establece las operaciones básicas CRUD (Crear, Leer, Actualizar, Eliminar)
   /// para la entidad de carreras, siguiendo el patrón de diseño Repository.
   /// </remarks>
   public interface ICarreraRepositorio
   {
      /// <summary>
      /// Registra una nueva carrera en el sistema
      /// </summary>
      /// <param name="carrera">Entidad con los datos de la carrera a registrar</param>
      /// <returns>Tarea asincrónica que representa la operación</returns>
      public Task InsertarCarrera(E_Carrera carrera);

      /// <summary>
      /// Elimina una carrera existente del sistema
      /// </summary>
      /// <param name="idCarrera">Identificador único de la carrera a eliminar</param>
      /// <returns>Tarea asincrónica que representa la operación</returns>
      public Task BorrarCarrera(int idCarrera);

      /// <summary>
      /// Actualiza los datos de una carrera existente
      /// </summary>
      /// <param name="carrera">Entidad con los datos actualizados de la carrera</param>
      /// <returns>Tarea asincrónica que representa la operación</returns>
      public Task ModificarCarrera(E_Carrera carrera);

      /// <summary>
      /// Obtiene los datos de una carrera específica
      /// </summary>
      /// <param name="idCarrera">Identificador único de la carrera a buscar</param>
      /// <returns>Tarea asincrónica que devuelve la entidad encontrada o null</returns>
      public Task<E_Carrera> BuscarCarrera(int idCarrera);

      /// <summary>
      /// Obtiene el listado completo de carreras registradas
      /// </summary>
      /// <returns>Tarea asincrónica que devuelve una colección enumerable de carreras</returns>
      public Task<IEnumerable<E_Carrera>> ListarCarreras();

      /// <summary>
      /// Obtiene carreras filtradas por un criterio de búsqueda
      /// </summary>
      /// <param name="criterioBusqueda">Texto opcional para filtrar los resultados (búsqueda por Clave, Nombre o Alias)</param>
      /// <returns>Tarea asincrónica que devuelve una colección enumerable de carreras que coinciden con el criterio</returns>
      public Task<IEnumerable<E_Carrera>> ListarCarreras(string criterioBusqueda = null);
   }
}