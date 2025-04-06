using Entidades.DTO;
using Entidades.Modelos;
using Negocios;

namespace Servicios
{
   public class CarreraServicios
   {
      private readonly CarreraNegocios _carreraNegocios;

      public CarreraServicios(CarreraNegocios carreraNegocios)
      {
         _carreraNegocios = carreraNegocios;
      }
      public async Task<string> InertarCarrrera(E_Carrera carrera)
      {
         return await _carreraNegocios.InsertarCarrera(carrera);
      }
      public async Task<string> BorrarCarrrera(int idCarrera)
      {
         return await _carreraNegocios.BorrarCarrera(idCarrera);
      }
      public async Task<string> ModificarCarrera(E_Carrera carrera)
      {
         return await _carreraNegocios.ModificarCarrera(carrera);
      }
      public async Task<E_Carrera> BuscarCarrera(int idCarrera)
      {
         return await _carreraNegocios.BuscarCarrera(idCarrera);
      }

      public async Task<IEnumerable<E_Carrera>> ListarCarrera()
      {
         return await _carreraNegocios.ListarCarreras();
      }
      public async Task<IEnumerable<E_Carrera>> ListarCarreras(string criterioBusqueda)
      {
         return await _carreraNegocios.ListarCarreras(criterioBusqueda);
      }
   }
}
