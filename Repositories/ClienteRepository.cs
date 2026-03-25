using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAll()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetById(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task Add(Cliente entity)
    {
        await _context.Clientes.AddAsync(entity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}