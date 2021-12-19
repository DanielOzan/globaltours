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
using Core.Interfaces;
using Core.Especificacion;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        private readonly IRepository<Lugar> _lugarRepo;
        private readonly IRepository<Categoria> _CategoriaRepo ;
        private  readonly IRepository<Pais> _PaisRepo ;
        private readonly IMapper _mapper;

        public LugaresController(IRepository<Lugar> lugarRepo,IRepository<Categoria> categoriaRepo,IRepository<Pais> paisRepo, IMapper mapper)
        {
            _mapper = mapper;
            _PaisRepo = paisRepo;
            _CategoriaRepo = categoriaRepo;
            _lugarRepo = lugarRepo;
    
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LugarDto>>> GetLugares()
        {
           var espec= new LugaresConPaisCategoriaEspecificacion();
           var lugares=  await  _lugarRepo.ObtenerTodosEspec(espec);
           return Ok( _mapper.Map<IReadOnlyList<Lugar>,IReadOnlyList<LugarDto>>(lugares));
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<LugarDto>> GetLugar(int id)
        {
              var espec= new LugaresConPaisCategoriaEspecificacion();
              var lugar=  await  _lugarRepo.ObtenerEspec(espec);
            return Ok(_mapper.Map<Lugar,LugarDto>(lugar));
        }
        
        [HttpGet("paises")]
            public async Task<ActionResult<List<Pais>>> GetPaises()  
            {
                return Ok(await _PaisRepo.ObtenerTodoAsync());

            }
         [HttpGet("categorias")]
            public async Task<ActionResult<List<Pais>>> GetCategorias()  
            {
                return Ok(await _CategoriaRepo.ObtenerTodoAsync());
            }
    }

}