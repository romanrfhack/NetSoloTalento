using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetSoloTalento.Middleware;
using NetSoloTalento.Models;
using NetSoloTalento.Token;

namespace NetSoloTalento.Data.Articulos;

public class ArticuloRepository : IArticuloRepository
{
    private readonly AppDbContext _contexto;
    private readonly IUsuarioSesion _usuarioSesion;
    private readonly UserManager<Usuario> _userManager;

    public ArticuloRepository( AppDbContext contexto, IUsuarioSesion sesion, UserManager<Usuario> userManager)
    {
        _contexto = contexto;
        _usuarioSesion = sesion;
        _userManager = userManager;
    }    
    public async Task CreateArticulo(Articulo articulo)
    {
       var usuario = await  _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
       if (usuario is null)
       {
            throw new MiddlewareException(
                HttpStatusCode.Unauthorized,
                new {mensaje = "El usuario no es valido para hacer esta insercion"}
            );
       }
       if(articulo is null)
       {
            throw new MiddlewareException(
                HttpStatusCode.BadRequest,
                new {mensaje = "Los datos del articulo son incorrectos"}
            );
       }       
       articulo.FechaCreacion = DateTime.Now;
       articulo.UsuarioId =  Guid.Parse(usuario!.Id);

       await _contexto.Articulos!.AddAsync(articulo);
    }

    public async Task DeleteArticulo(int id)
    {
        var articulo = await _contexto.Articulos!
                            .FirstOrDefaultAsync(x => x.Id == id);
        _contexto.Articulos!.Remove(articulo!);
    }

    public async Task<IEnumerable<Articulo>> GetAllArticulos()
    {
       return await _contexto.Articulos!.ToListAsync();
    }

    public async Task<Articulo> GetArticuloById(int id)
    {
        var resultado = await _contexto.Articulos!.FirstOrDefaultAsync(x => x.Id == id)!;
        if (resultado is null)
        {        
            throw new MiddlewareException(
                HttpStatusCode.BadRequest, 
                new  {mensaje = "El articulo no existe en la base de datos"}
            );        
        }
        return resultado; 
    }

    public async Task<bool> SaveChanges()
    {
       return (  (await _contexto.SaveChangesAsync())   >= 0);
    }
}