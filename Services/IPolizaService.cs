public interface IPolizaService {
    Task<Poliza> EmitirPoliza(EmitirPolizaDto dto);
    Task<List<Poliza>> ObtenerPolizas();
    Task<Poliza> ObtenerPorId(int id);
}