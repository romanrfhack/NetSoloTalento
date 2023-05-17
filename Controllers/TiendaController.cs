using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetSoloTalento.Dtos.TiendaDtos;
using NetSoloTalento.Data.Tiendas;
using NetSoloTalento.Middleware;
using NetSoloTalento.Models;

namespace NetKubernetes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TiendaController : ControllerBase{

    private readonly TiendasRepository _repository;
    private IMapper _mapper;
    
    public TiendaController(
        TiendasRepository repository,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TiendaResponseDto>>> GetTiendas()
    {
        var tienda = await _repository.GetAllTiendas();
        //Deberia estar en otra capa        
        var tiendas = _mapper.Map<IEnumerable<TiendaResponseDto>>(tienda);        
        return Ok(tiendas);
    }    

    [HttpGet("{id}", Name = "GetTiendaById")]
    public async Task<ActionResult<TiendaResponseDto>> GetTiendaById(int id)
    {
        var tienda = await  _repository.GetTiendaById(id);
        if(tienda is null)
        {
            throw new MiddlewareException(
                HttpStatusCode.NotFound,
                new {mensaje = $"No se encontro el registro de la tienda por este id {id}"}
            );
        }
        return Ok(_mapper.Map<TiendaResponseDto>(tienda));
    }

    [HttpPost]
    public async Task<ActionResult<TiendaResponseDto>> CreateTienda( [FromBody] TiendaResponseDto tienda)
    {
        var tiendaModel = _mapper.Map<Tienda>(tienda);
        await _repository.CreateTienda(tiendaModel);
        await _repository.SaveChanges();
        var tiendaResponse = _mapper.Map<TiendaResponseDto>(tiendaModel);
        return CreatedAtRoute(nameof(GetTiendaById), new {tiendaResponse.Id}, tiendaResponse);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTienda(int id)
    {
        await _repository.DeleteTienda(id);
        await _repository.SaveChanges();
        return Ok();
    }
}