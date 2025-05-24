using Microsoft.EntityFrameworkCore;
using S1_ABD.Models;

namespace S1_ABD.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RegistroUso> RegistroUsos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.Property(e => e.IsUsing)
                  .HasColumnType("NUMBER(1)")
                  .HasConversion<int>();
        });
    }
}