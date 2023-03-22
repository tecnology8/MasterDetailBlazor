using MasterDetailBlazor.Shared;

namespace MasterDetailBlazor.Client.Services
{
    public interface IVentaService
    {
        Task<bool> Guardar(VentaDTO ventaDTO);
    }
}
