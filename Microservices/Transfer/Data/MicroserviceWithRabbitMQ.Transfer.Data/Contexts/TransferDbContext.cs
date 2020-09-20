using MicroserviceWithRabbitMQ.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceWithRabbitMQ.Transfer.Data.Contexts
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}