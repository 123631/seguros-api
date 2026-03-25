public class Cliente {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
    public string Correo { get; set; }
    public ICollection<Poliza> Polizas { get; set; }
}