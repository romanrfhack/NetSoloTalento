using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetSoloTalento.Models;

public class Venta {
    [Key]
    [Required]
    public int Id { get; set; }
    public List<Articulo>? Articulos { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public Guid? UsuarioId { get; set; }
}