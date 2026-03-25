public class EmitirPolizaDto {
    public int ClienteId { get; set; }
    public VehiculoDto Vehiculo { get; set; }
    public List<int> CoberturasIds { get; set; }
}

public class VehiculoDto {
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public decimal ValorComercial { get; set; }
}