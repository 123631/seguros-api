public class Vehiculo {
    public int Id { get; set; }
    public required string Placa { get; set; }
    public required string Marca { get; set; }
    public required string Modelo { get; set; }
    public required int Anio { get; set; }
    public required decimal ValorComercial { get; set; }
    public List<Poliza> Polizas { get; set; } = new();
}