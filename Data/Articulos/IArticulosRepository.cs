using NetSoloTalento.Models;

namespace NetSoloTalento.Data.Articulos;

public interface IArticuloRepository {

    Task<bool> SaveChanges();
    Task<IEnumerable<Articulo>> GetAllArticulos();
    Task<Articulo> GetArticuloById(int id);
    Task CreateArticulo(Articulo articulo);
    Task DeleteArticulo(int id);
}