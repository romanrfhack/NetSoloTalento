using System.Net.Mime;
using Microsoft.AspNetCore.Identity;
using NetSoloTalento.Models;

namespace NetSoloTalento.Data;

public class LoadDatabase {

    public static async Task InsertarData(AppDbContext context, UserManager<Usuario> usuarioManager)
    {
        if(!usuarioManager.Users.Any())
        {
            var usuario = new Usuario {
                Nombre = "Roman",
                Apellido = "Romero",
                Email = "romanrfhack@gmail.com",
                UserName = "roman.romero",
                Telefono = "1234567890"
            };
            await usuarioManager.CreateAsync(usuario, "PasswordST123$");
        }        

        if(!context.Tienda!.Any())
        {
            context.Tienda!.AddRange(
                new Tienda{                    
                    Sucursal = "Amazon Mexico",
                    Direccion = "Juan Salvador Agraz 73, Lomas de Santa Fe, Contadero, Cuajimalpa de Morelos, 05348 Ciudad de México, CDMX",                                        
                    FechaCreacion = DateTime.Now
                },
                new Tienda{
                    Sucursal = "Amazon USA",
                    Direccion = "2111 7th Avenue, Seattle, Washington, Estados Unidos",
                    FechaCreacion = DateTime.Now
                }
            );
        }        
        context.SaveChanges();

        if(!context.Articulos!.Any())
        {
            context.Articulos!.AddRange(
                new Articulo{                    
                    Codigo = "MDV106B-2AV",
                    Descripcion = "Casio - Reloj Casual De Cuarzo Inspirado En Diver Para Hombre",
                    Precio = 1554,
                    Imagen =  "https://m.media-amazon.com/images/I/613kS8sIRcL._AC_SY741_.jpg",
                    Stock = 10,
                    FechaCreacion = DateTime.Now
                },
                new Articulo{
                    Codigo = "MDV-106B-1A3VCF",
                    Descripcion = "Casio Reloj deportivo de cuarzo para hombre de acero inoxidable con correa de plástico, color negro, 26",
                    Precio = 1436,
                    Imagen =  "https://m.media-amazon.com/images/I/81UblpWUXJL._AC_SY741_.jpg",
                    Stock = 15,
                    FechaCreacion = DateTime.Now
                }
            );
        }        
        context.SaveChanges();
    }
}