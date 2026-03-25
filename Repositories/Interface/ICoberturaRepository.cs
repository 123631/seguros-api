public interface ICoberturaRepository : IGenericRepository<Cobertura>
{
    Task<List<Cobertura>> GetByIds(List<int> ids);
}