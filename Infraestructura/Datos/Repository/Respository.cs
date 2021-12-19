using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Especificacion;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repository
{
    public class Respository<T> : IRepository<T> where T : class

    {
        private readonly ApplicationDbContext _db;
        public   Respository(ApplicationDbContext db)
        {         
            _db = db;
        }

        public async Task<T> ObtenerAsync(int id)
        {
                 return await  _db.Set<T>().FindAsync(id);  
        }

     

        public async Task<IReadOnlyList<T>> ObtenerTodoAsync()
        {
               return await  _db.Set<T>().ToListAsync();
        }

           public async Task<T> ObtenerEspec(IEspecificacion<T> espec)
        {
           return await  AplicarEspecificacion(espec).FirstOrDefaultAsync();
        
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosEspec(IEspecificacion<T> espec)
        {
              return await  AplicarEspecificacion(espec).ToListAsync();

        }
        
        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> espec)
        {
            return EvaluadorEspecificacion<T>.GetQuery(_db.Set<T>().AsQueryable(),espec);

        }
    }
}