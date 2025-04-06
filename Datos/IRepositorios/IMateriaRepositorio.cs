using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Modelos;

namespace Datos.IRepositorios
{
    interface IMateriaRepositorio
    {
        public Task<List<E_Materia>> ListMaterias();

        public Task<bool> InsertarMateria(E_Materia materia);

        public Task<E_Materia> BuscarMateria(int id);

        public Task<bool> ActualizarMateria(int id,E_Materia materia);

        public Task<bool> EliminarMateria(int id);
    }
}
