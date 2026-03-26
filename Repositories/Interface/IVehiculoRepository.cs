public interface IVehiculoRepository {
    Task<Vehiculo?> GetByPlaca(string placa);
    Task Add(Vehiculo vehiculo);
    Task Save();
}
