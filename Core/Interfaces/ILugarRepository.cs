using System.Collections.Generic;
using System.Threading.Tasks;
using Core.model;

namespace Infraestructura.Datos.Repository
{
    public interface ILugarRepository
    {
         Task<List<Lugar>> GetAllLugaresAsync();
         Task<Lugar> GetLugarAsync(int id);
    }
}