public interface IPolizaCoberturaRepository
{
    Task AddRange(IEnumerable<PolizaCobertura> polizaCoberturas);
    Task Save();
}