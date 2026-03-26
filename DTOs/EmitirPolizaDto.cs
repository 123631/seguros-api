using System.ComponentModel.DataAnnotations;

public class EmitirPolizaDto
{
    public int ClienteId { get; set; }

    public required VehiculoDto Vehiculo { get; set; }

    public required List<int> CoberturasIds { get; set; }
}

public class VehiculoDto
{
    [Required(ErrorMessage = "La placa es obligatoria.")]
    [StringLength(20, ErrorMessage = "La placa no puede superar los 20 caracteres.")]
    public required string Placa { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria.")]
    [StringLength(20, ErrorMessage = "La marca no puede superar los 20 caracteres.")]
    public required string Marca { get; set; }

    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El modelo no puede superar los 50 caracteres.")]
    public required string Modelo { get; set; }

    [Required(ErrorMessage = "El año es obligatorio.")]
    [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
    
    public int Anio { get; set; }

    [Required(ErrorMessage = "El valor comercial es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El valor comercial debe ser un número positivo.")]
    public decimal ValorComercial { get; set; }
}