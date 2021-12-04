using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
  
        public LugaresController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> GetLugares()
        {
            return  Ok(await _db.Lugar.ToListAsync());
        }

           [HttpGet("{id}")]
        public  async Task<ActionResult<Lugar>> GetLugar(int id)
        {

            return Ok(await _db.Lugar.FirstOrDefaultAsync(l=> l.Id==id));
        }
        
    }
}