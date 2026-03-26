using Microsoft.EntityFrameworkCore;
public class PolizaService : IPolizaService
{
    private readonly IPolizaRepository _polizaRepo;
    private readonly IClienteRepository _clienteRepo;
    private readonly ICoberturaRepository _coberturaRepo;
    private readonly AppDbContext _context;

    private readonly IPolizaCoberturaRepository _polizaCoberturaRepo;
    
    private readonly IVehiculoRepository _vehiculoRepo;

    public PolizaService(
        IPolizaRepository polizaRepo,
        IClienteRepository clienteRepo,
        ICoberturaRepository coberturaRepo,
        IVehiculoRepository vehiculoRepo,
        IPolizaCoberturaRepository polizaCoberturaRepo,     
        AppDbContext context
    ) {
        _polizaRepo = polizaRepo;
        _clienteRepo = clienteRepo;
        _coberturaRepo = coberturaRepo;
        _vehiculoRepo = vehiculoRepo;
        _polizaCoberturaRepo = polizaCoberturaRepo;
        _context = context;
    }

    public async Task<Poliza> EmitirPoliza(EmitirPolizaDto dto) {
        var cliente = await _clienteRepo.GetById(dto.ClienteId);
        if (cliente == null)
            throw new Exception("El cliente no existe");

        var vehiculo = await _vehiculoRepo.GetByPlaca(dto.Vehiculo.Placa);

        if (vehiculo == null) {
            if (dto.Vehiculo.ValorComercial <= 0)
                throw new Exception("El valor comercial del vehículo debe ser positivo.");
            vehiculo = new Vehiculo {
                Placa = dto.Vehiculo.Placa,
                Marca = dto.Vehiculo.Marca,
                Modelo = dto.Vehiculo.Modelo,
                Anio = dto.Vehiculo.Anio,
                ValorComercial = dto.Vehiculo.ValorComercial
            };

            await _vehiculoRepo.Add(vehiculo);
            await _vehiculoRepo.Save();
        }

        var coberturas = await _coberturaRepo.GetByIds(dto.CoberturasIds);

        if (coberturas == null || !coberturas.Any())
            throw new Exception("Las coberturas seleccionadas son inválidas, o inexistentes.");

        var prima = coberturas.Sum(c => c.MontoCobertura);

        var poliza = new Poliza {
            ClienteId = dto.ClienteId,
            VehiculoId = vehiculo.Id,
            FechaEmision = DateTime.UtcNow,
            NumeroPoliza = $"POL-{DateTime.UtcNow.Ticks}",
            SumaAsegurada = vehiculo.ValorComercial,
            PrimaTotal = prima
        };

        await _polizaRepo.Add(poliza);
        await _polizaRepo.Save();

        var polizaCoberturas = coberturas.Select(c => new PolizaCobertura {
            PolizaId = poliza.Id,
            CoberturaId = c.Id
        }).ToList();

        await _polizaCoberturaRepo.AddRange(polizaCoberturas);
        await _polizaCoberturaRepo.Save();

        return poliza;
    }

    public async Task<List<Poliza>> ObtenerPolizas() {
        return await _polizaRepo.GetAll();
    }

    public async Task<Poliza?> ObtenerPorId(int id) {
        return await _polizaRepo.GetPolizaDetalle(id);
    }
}