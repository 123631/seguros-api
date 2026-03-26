using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
    public DbSet<Cobertura> Coberturas { get; set; } = null!;
    public DbSet<Poliza> Polizas { get; set; } = null!;
    public DbSet<PolizaCobertura> PolizaCoberturas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cobertura>()
            .Property(x => x.MontoCobertura)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Poliza>()
            .Property(x => x.PrimaTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Poliza>()
            .Property(x => x.SumaAsegurada)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Vehiculo>()
            .Property(x => x.ValorComercial)
            .HasPrecision(18, 2);
        
        modelBuilder.Entity<PolizaCobertura>()
            .HasOne(pc => pc.Poliza)
            .WithMany(p => p.PolizaCoberturas)
            .HasForeignKey(pc => pc.PolizaId);
    }
}