using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MicroserviceWithRabbitMQ.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroserviceWithRabbitMQ.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
