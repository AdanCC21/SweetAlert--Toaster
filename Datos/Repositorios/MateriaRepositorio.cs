using Datos.Contexto;
using Datos.IRepositorios;
using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private readonly D_ContextoBD _contextoBD;

        public MateriaRepositorio(D_ContextoBD contextoBD)
        {
            _contextoBD = contextoBD;
        }

        public async Task<bool> ActualizarMateria(int id, E_Materia materia)
        {
            try
            {
                var materiaExist = await BuscarMateria(id);
                if (materiaExist != null)
                {
                    materiaExist.ClaveMateria = materia.ClaveMateria;
                    materiaExist.NombreMateria = materia.NombreMateria;

                    _contextoBD.Materias.Update(materiaExist);
                    await _contextoBD.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<E_Materia> BuscarMateria(int id)
        {
            return await _contextoBD.Materias.FindAsync(id);
        }

        public async Task<bool> EliminarMateria(int id)
        {
            try
            {
                var materia = await BuscarMateria(id);
                if (materia != null)
                {
                    _contextoBD.Materias.Remove(materia);
                    await _contextoBD.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> InsertarMateria(E_Materia materia)
        {
            try
            {
                await _contextoBD.Materias.AddAsync(materia);
                await _contextoBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<E_Materia>> ListMaterias()
        {
            try
            {
                return await _contextoBD.Materias.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<E_Materia>();
            }
        }
    }
}
