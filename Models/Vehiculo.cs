public class Vehiculo {
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public decimal ValorComercial { get; set; }
    public ICollection<Poliza> Polizas { get; set; }
}