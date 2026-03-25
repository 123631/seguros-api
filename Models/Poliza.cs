public class Poliza {
    public int Id { get; set; }
    public string NumeroPoliza { get; set; }
    public int ClienteId { get; set; }
    public int VehiculoId { get; set; }
    public DateTime FechaEmision { get; set; }
    public decimal SumaAsegurada { get; set; }
    public decimal PrimaTotal { get; set; }

    public Cliente Cliente { get; set; }
    public Vehiculo Vehiculo { get; set; }

    public ICollection<PolizaCobertura> PolizaCoberturas { get; set; }
}

public class PolizaCobertura {
    public int PolizaId { get; set; }
    public Poliza Poliza { get; set; }

    public int CoberturaId { get; set; }
    public Cobertura Cobertura { get; set; }
}