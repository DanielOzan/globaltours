using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificacion;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> ObtenerAsync(int id);
        Task<IReadOnlyList<T>> ObtenerTodoAsync();

        Task<T> ObtenerEspec (IEspecificacion<T> espec);

         Task<IReadOnlyList<T>> ObtenerTodosEspec(IEspecificacion<T> espec);
    }
}