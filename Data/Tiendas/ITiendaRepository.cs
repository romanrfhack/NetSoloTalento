using NetSoloTalento.Models;

namespace NetSoloTalento.Data.Tiendas;

public interface ITiendasRepository {

    Task<bool> SaveChanges();
    Task<IEnumerable<Tienda>> GetAllTiendas();
    Task<Tienda> GetTiendaById(int id);
    Task CreateTienda(Tienda tienda);
    Task DeleteTienda(int id);
}