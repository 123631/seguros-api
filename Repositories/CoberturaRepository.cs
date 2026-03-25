using Microsoft.EntityFrameworkCore;

public class CoberturaRepository : ICoberturaRepository
{
    private readonly AppDbContext _context;

    public CoberturaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cobertura>> GetAll()
    {
        return await _context.Coberturas.ToListAsync();
    }

    public async Task<Cobertura> GetById(int id)
    {
        return await _context.Coberturas.FindAsync(id);
    }

    public async Task<List<Cobertura>> GetByIds(List<int> ids)
    {
        return await _context.Coberturas
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }

    public async Task Add(Cobertura entity)
    {
        await _context.Coberturas.AddAsync(entity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}