using Microsoft.AspNetCore.Identity;

namespace NetSoloTalento.Models;

public class Usuario : IdentityUser {
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Telefono { get; set; }    
}