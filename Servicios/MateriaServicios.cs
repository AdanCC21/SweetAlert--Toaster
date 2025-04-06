using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Modelos;
using Negocios;

namespace Servicios
{
    public class MateriaServicios
    {
        private readonly MateriasNegocios MatNeg;

        public MateriaServicios(MateriasNegocios MatNeg)
        {
            this.MatNeg = MatNeg;
        }

        public async Task<bool> InsertarMateria(E_Materia materia)
        {
            return await MatNeg.InsertarMateria(materia);
        }

        public async Task<bool> BorrarMateira(int id)
        {
            return await MatNeg.EliminarMateria(id);
        }
        public async Task<bool> ActualizarMateria(int id, E_Materia materia)
        {
            return await MatNeg.ActualizarMateria(id, materia);
        }

        public async Task<List<E_Materia>> ListarMaterias()
        {
            return await MatNeg.ListarMaterias();
        }

        public async Task<E_Materia> BuscarMateria(int id)
        {
            return await MatNeg.BuscarMateria(id);
        }

    }
}
