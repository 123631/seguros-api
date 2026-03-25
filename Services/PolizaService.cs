public class PolizaService : IPolizaService
{
    private readonly IPolizaRepository _polizaRepo;
    private readonly IClienteRepository _clienteRepo;
    private readonly ICoberturaRepository _coberturaRepo;
    private readonly AppDbContext _context;

    public PolizaService(
        IPolizaRepository polizaRepo,
        IClienteRepository clienteRepo,
        ICoberturaRepository coberturaRepo,
        AppDbContext context)
    {
        _polizaRepo = polizaRepo;
        _clienteRepo = clienteRepo;
        _coberturaRepo = coberturaRepo;
        _context = context;
    }

    public async Task<Poliza> EmitirPoliza(EmitirPolizaDto dto)
    {
        var cliente = await _clienteRepo.GetById(dto.ClienteId);
        if (cliente == null)
            throw new Exception("Cliente no existe");

        var vehiculo = new Vehiculo
        {
            Placa = dto.Vehiculo.Placa,
            Marca = dto.Vehiculo.Marca,
            Modelo = dto.Vehiculo.Modelo,
            Anio = dto.Vehiculo.Anio,
            ValorComercial = dto.Vehiculo.ValorComercial
        };

        _context.Vehiculos.Add(vehiculo);
        await _context.SaveChangesAsync();

        var coberturas = await _coberturaRepo.GetByIds(dto.CoberturasIds);

        var prima = coberturas.Sum(c => c.MontoCobertura);

        var poliza = new Poliza
        {
            ClienteId = dto.ClienteId,
            VehiculoId = vehiculo.Id,
            FechaEmision = DateTime.UtcNow,
            NumeroPoliza = $"POL-{DateTime.UtcNow.Ticks}",
            SumaAsegurada = vehiculo.ValorComercial,
            PrimaTotal = prima,
            PolizaCoberturas = coberturas.Select(c => new PolizaCobertura
            {
                CoberturaId = c.Id
            }).ToList()
        };

        await _polizaRepo.Add(poliza);
        await _polizaRepo.Save();

        return poliza;
    }

    public async Task<List<Poliza>> ObtenerPolizas()
    {
        return await _polizaRepo.GetAll();
    }

    public async Task<Poliza> ObtenerPorId(int id)
    {
        return await _polizaRepo.GetPolizaDetalle(id);
    }
}