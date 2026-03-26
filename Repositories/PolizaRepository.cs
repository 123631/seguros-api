using Microsoft.EntityFrameworkCore;

public class PolizaRepository : IPolizaRepository
{
    private readonly AppDbContext _context;

    public PolizaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Poliza>> GetAll()
    {
        return await _context.Polizas
            .Include(p => p.Cliente)
            .Include(p => p.Vehiculo)
            .ToListAsync();
    }

    public async Task<Poliza?> GetById(int id)
    {
        return await _context.Polizas.FindAsync(id);
    }

    public async Task<Poliza?> GetPolizaDetalle(int id)
    {
        return await _context.Polizas
            .Include(p => p.Cliente)
            .Include(p => p.Vehiculo)
            .Include(p => p.PolizaCoberturas)
            .ThenInclude(pc => pc.Cobertura)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Poliza entity)
    {
        await _context.Polizas.AddAsync(entity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}