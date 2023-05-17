using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using NetSoloTalento.Middleware;
using NetSoloTalento.Models;
using NetSoloTalento.Token;

namespace NetSoloTalento.Data.Tiendas;

public class TiendasRepository : ITiendasRepository
{
    private readonly AppDbContext _contexto;
    private readonly IUsuarioSesion _usuarioSesion;
    private readonly UserManager<Usuario> _userManager;

    public TiendasRepository(
        AppDbContext contexto,
        IUsuarioSesion sesion,
        UserManager<Usuario> userManager
    )
    {
        _contexto = contexto;
        _usuarioSesion = sesion;
        _userManager = userManager;
    }    
    public async Task CreateTienda(Tienda tienda)
    {
       var usuario = await  _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
       if (usuario is null)
       {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El usuario no es valido para hacer esta insercion"}
            );
       }
       if(tienda is null)
       {
            throw new MiddlewareException(
                HttpStatusCode.BadRequest,
                new {mensaje = "Los datos de la tienda son incorrectos"}
            );
       }       
       tienda.FechaCreacion = DateTime.Now;
       tienda.UsuarioId =  Guid.Parse(usuario!.Id);

       await _contexto.Tienda!.AddAsync(tienda);
    }

    public async Task DeleteTienda(int id)
    {
        var tienda = await _contexto.Tienda!
                            .FirstOrDefaultAsync(x => x.Id == id);
        _contexto.Tienda!.Remove(tienda!);
    }

    public async Task<IEnumerable<Tienda>> GetAllTiendas()
    {
       return await _contexto.Tienda!.ToListAsync();
    }

    public async Task<Tienda> GetTiendaById(int id)
    {
        var resultado = await _contexto.Tienda!.FirstOrDefaultAsync(x => x.Id == id)!;
        if (resultado is null)
        {        
            throw new MiddlewareException(
                HttpStatusCode.BadRequest, 
                new  {mensaje = "El registro de la tienda no existe en la base de datos"}
            );        
        }
        return resultado; 
    }

    public async Task<bool> SaveChanges()
    {
       return (  (await _contexto.SaveChangesAsync())   >= 0);
    }
}