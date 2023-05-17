using NetSoloTalento.Models;
namespace NetSoloTalento.Dtos.TiendaDtos;

public class TiendaRequestDto {
    public string? Sucursal { get; set; }
    public string? Dirección { get; set; }
    public DateTime? FechaCreacion { get; set; }

    public List<Articulo>? Articulos { get; set; }

}