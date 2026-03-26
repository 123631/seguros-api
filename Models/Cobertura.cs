public class Cobertura {
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required decimal MontoCobertura { get; set; }
    public List<PolizaCobertura> PolizaCoberturas { get; set; } = new();
}