using Microsoft.EntityFrameworkCore;

public class VehiculoRepository : IVehiculoRepository {
    private readonly AppDbContext _context;

    public VehiculoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vehiculo?> GetByPlaca(string placa)
    {
        return await _context.Vehiculos
            .FirstOrDefaultAsync(v => v.Placa == placa);
    }

    public async Task Add(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}