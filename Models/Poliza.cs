public class Poliza
{
    public int Id { get; set; }

    public required string NumeroPoliza { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public int VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public decimal SumaAsegurada { get; set; }
    public decimal PrimaTotal { get; set; }

    public List<PolizaCobertura> PolizaCoberturas { get; set; } = new();
}

public class PolizaCobertura {
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public Poliza Poliza { get; set; } = null!;

    public int CoberturaId { get; set; }
    public Cobertura Cobertura { get; set; } = null!;
}