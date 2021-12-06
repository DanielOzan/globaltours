using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos.Repository
{

    public class LugarRepository : ILugarRepository
    {
        private readonly ApplicationDbContext _db;
     

        public LugarRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<List<Lugar>> GetAllLugaresAsync()
        {          
         
            return await  _db.Lugar.Include(p=>p.Pais) //Eager loading
            .Include(c=>c.Categoria)
            .ToListAsync();
        }
        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await  _db.Lugar.Include(p=>p.Pais) //Eager loading
                                .Include(c=>c.Categoria)
                                 .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}