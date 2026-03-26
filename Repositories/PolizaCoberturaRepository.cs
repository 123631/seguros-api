public class PolizaCoberturaRepository : IPolizaCoberturaRepository {
    private readonly AppDbContext _context;

    public PolizaCoberturaRepository(AppDbContext context) {
        _context = context;
    }

    public async Task AddRange(IEnumerable<PolizaCobertura> polizaCoberturas){
        await _context.PolizaCoberturas.AddRangeAsync(polizaCoberturas);
    }

    public async Task Save() {
        await _context.SaveChangesAsync();
    }
}