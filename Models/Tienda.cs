using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetSoloTalento.Models;

public class Tienda : IdentityUser {
    [Key]
    [Required]
    public int Id { get; set; }
    public string? Sucursal { get; set; }
    public string? Direccion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public List<Articulo>? Articulos { get; set; }
    public Guid? UsuarioId { get; set; }
}