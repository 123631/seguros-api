using System.ComponentModel.DataAnnotations;

namespace SegurosApi.DTOs;
public class PolizaResponseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El número de póliza es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de póliza no puede superar los 50 caracteres.")]
    public required string NumeroPoliza { get; set; }

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "La prima total es obligatoria.")]
    public decimal PrimaTotal { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre del cliente no puede superar los 100 caracteres.")]
    public required string ClienteNombre { get; set; }

    [Required(ErrorMessage = "La placa del vehículo es obligatoria.")]
    [StringLength(20, ErrorMessage = "La placa del vehículo no puede superar los 20 caracteres.")]
    public required string VehiculoPlaca { get; set; }

    [Required(ErrorMessage = "Las coberturas son obligatorias.")]
    public List<string> Coberturas { get; set; } = new();
}