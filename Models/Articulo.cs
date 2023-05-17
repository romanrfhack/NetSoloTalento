using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetSoloTalento.Models;

public class Articulo {
    [Key]
    [Required]
    public int Id { get; set; }        
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }
    public string Imagen { get; set; }
    public int Stock { get; set; }
    public Guid? UsuarioId { get; set; }
    public DateTime? FechaCreacion { get; set; }
}