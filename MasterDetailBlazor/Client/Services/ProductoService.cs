using MasterDetailBlazor.Shared;
using System.Net.Http.Json;

namespace MasterDetailBlazor.Client.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        public async Task<List<ProductoDTO>> Lista()
        {
            var lista = new List<ProductoDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto");

            return lista!;
        }
    }
}
