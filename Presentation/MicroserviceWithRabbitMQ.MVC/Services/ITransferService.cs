using System.Threading.Tasks;
using MicroserviceWithRabbitMQ.MVC.Models.DTO;

namespace MicroserviceWithRabbitMQ.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
