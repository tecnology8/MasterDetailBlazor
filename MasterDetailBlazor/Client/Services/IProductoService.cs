using MasterDetailBlazor.Shared;

namespace MasterDetailBlazor.Client.Services
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista();
    }
}
