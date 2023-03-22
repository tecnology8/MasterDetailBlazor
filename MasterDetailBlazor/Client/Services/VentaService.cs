using MasterDetailBlazor.Shared;
using System.Net.Http.Json;

namespace MasterDetailBlazor.Client.Services
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;

        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Guardar(VentaDTO ventaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Venta", ventaDTO);
            var result = response.IsSuccessStatusCode;
            return result;
        }
    }
}
