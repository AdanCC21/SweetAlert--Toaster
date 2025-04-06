using Datos.Repositorios;
using Entidades.Modelos;

namespace Negocios
{
   /// <summary>
   /// Clase que implementa la lógica de negocio para la gestión de carreras 
   /// </summary>
   /// <remarks>
   /// Coordina las operaciones entre la capa de presentación y el repositorio de datos,
   /// aplicando reglas de negocio cuando sea necesario.
   /// </remarks>
   public class CarreraNegocios
   {
      private readonly CarreraRepositorio _carreraRepositorio;

      /// <summary>
      /// Constructor que inicializa el repositorio de carreras
      /// </summary>
      /// <param name="carreraRepositorio">Instancia del repositorio inyectada por dependencia</param>
      public CarreraNegocios(CarreraRepositorio carreraRepositorio)
      {
         _carreraRepositorio = carreraRepositorio;
      }

      /// <summary>
      /// Registra una nueva carrera en el sistema
      /// </summary>
      /// <param name="carrera">Entidad con los datos de la carrera a registrar</param>
      /// <returns>Mensaje de confirmación de la operación</returns>
      public async Task<string> InsertarCarrera(E_Carrera carrera)
      {
         await _carreraRepositorio.InsertarCarrera(carrera);
         return "Exito: La carrera se insertó correctamente.";
      }

      /// <summary>
      /// Elimina una carrera del sistema
      /// </summary>
      /// <param name="idCarrera">Identificador único de la carrera a eliminar</param>
      /// <returns>Mensaje de confirmación de la operación</returns>
      public async Task<string> BorrarCarrera(int idCarrera)
      {
         await _carreraRepositorio.BorrarCarrera(idCarrera);
         return "Exito: La carrera se borró correctamente.";
      }

      /// <summary>
      /// Actualiza los datos de una carrera existente
      /// </summary>
      /// <param name="carrera">Entidad con los datos actualizados de la carrera</param>
      /// <returns>Mensaje de confirmación de la operación</returns>
      public async Task<string> ModificarCarrera(E_Carrera carrera)
      {
         await _carreraRepositorio.ModificarCarrera(carrera);
         return "Exito: La carrera se modificó correctamente.";
      }

      /// <summary>
      /// Obtiene los datos de una carrera específica
      /// </summary>
      /// <param name="idCarrera">Identificador único de la carrera a consultar</param>
      /// <returns>Entidad con los datos de la carrera solicitada</returns>
      public async Task<E_Carrera> BuscarCarrera(int idCarrera)
      {
         return await _carreraRepositorio.BuscarCarrera(idCarrera);
      }

      /// <summary>
      /// Obtiene el listado completo de carreras registradas
      /// </summary>
      /// <returns>Colección enumerable de todas las carreras</returns>
      public async Task<IEnumerable<E_Carrera>> ListarCarreras()
      {
         return await _carreraRepositorio.ListarCarreras();
      }

      /// <summary>
      /// Obtiene carreras que coinciden con el criterio de búsqueda
      /// </summary>
      /// <param name="criterioBusqueda">Texto para filtrar carreras (por nombre, clave o alias)</param>
      /// <returns>Colección enumerable de carreras que coinciden con el criterio</returns>
      public async Task<IEnumerable<E_Carrera>> ListarCarreras(string criterioBusqueda)
      {
         return await _carreraRepositorio.ListarCarreras(criterioBusqueda);
      }
   }
}