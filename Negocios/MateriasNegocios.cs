using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Datos.Repositorios;
using Entidades.Modelos;

namespace Negocios
{
    public class MateriasNegocios
    {
        private readonly MateriaRepositorio MatRep;

        public MateriasNegocios(MateriaRepositorio matRep)
        {
            MatRep = matRep;
        }

        public async Task<bool> InsertarMateria(E_Materia materia)
        {
            return await MatRep.InsertarMateria(materia);
        }

        public async Task<List<E_Materia>> ListarMaterias(E_Materia materia)
        {
            return await MatRep.ListMaterias();
        }

        public async Task<bool> EliminarMateria(int id)
        {
            return await MatRep.EliminarMateria(id);
        }

        public async Task<bool> ActualizarMateria(int id, E_Materia materia)
        {
            var res = await MatRep.ActualizarMateria(id, materia);
            return res;
        }
        
        public async Task<E_Materia> BuscarMateria(int id)
        {
            return await MatRep.BuscarMateria(id);
        }

        public async Task<List<E_Materia>> ListarMaterias()
        {
            return await MatRep.ListMaterias();
            throw new NotImplementedException();
        }
    }
}
