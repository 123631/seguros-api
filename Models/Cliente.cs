public class Cliente {
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Identificacion { get; set; }
    public required string Correo { get; set; }
    public List<Poliza> Polizas { get; set; } = new();
}