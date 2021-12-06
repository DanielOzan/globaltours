using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Datos;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.model;
using Infraestructura.Datos.Repository;
using API.Services;
using System.Reflection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly ILugarRepository _repo;
       

        public LugaresController(ILugarRepository repo)
        {
        _repo =repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Lugar>>> GetLugares()
        {
        
           
           return  Ok(await  _repo.GetAllLugaresAsync());
        }

           [HttpGet("{id}")]
        public async  Task<ActionResult<Lugar>> GetLugar(int id)
        {
            return Ok(await _repo.GetLugarAsync(id));
        }
        
    }

}