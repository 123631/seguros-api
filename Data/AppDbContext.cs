using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Cobertura> Coberturas { get; set; }
    public DbSet<Poliza> Polizas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PolizaCobertura>()
            .HasKey(pc => new { pc.PolizaId, pc.CoberturaId });

        modelBuilder.Entity<PolizaCobertura>()
            .HasOne(pc => pc.Poliza)
            .WithMany(p => p.PolizaCoberturas)
            .HasForeignKey(pc => pc.PolizaId);

        modelBuilder.Entity<PolizaCobertura>()
            .HasOne(pc => pc.Cobertura)
            .WithMany()
            .HasForeignKey(pc => pc.CoberturaId);
    }
}