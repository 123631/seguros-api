public interface IPolizaRepository : IGenericRepository<Poliza>
{
    Task<Poliza> GetPolizaDetalle(int id);
}