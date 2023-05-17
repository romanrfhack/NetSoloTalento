using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetSoloTalento.Models;

namespace NetSoloTalento.Data;

public class AppDbContext : IdentityDbContext<Usuario>{

 public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
 protected override void OnModelCreating(ModelBuilder builder)
 {
    base.OnModelCreating(builder);
 } 
 public DbSet<Articulo>? Articulos {get;set;}
 public DbSet<Venta>? Venta {get;set;}
 public DbSet<Tienda>? Tienda {get;set;}
}