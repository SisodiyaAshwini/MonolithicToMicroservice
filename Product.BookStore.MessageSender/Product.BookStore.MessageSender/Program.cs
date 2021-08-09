using Azure.Messaging.ServiceBus;
using System.Configuration;
using System.Threading.Tasks;

namespace Product.BookStore.MessageSender
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            var queue = ConfigurationManager.AppSettings["BookStoreQueue"];

            // Because ServiceBusClient implements IAsyncDisposable, we'll create it 
            // with "await using" so that it is automatically disposed for us.
            await using var client = new ServiceBusClient(connectionString);

            // The sender is responsible for publishing messages to the queue.
            ServiceBusSender sender = client.CreateSender(queue);
            ServiceBusMessage message = new ServiceBusMessage("This is the message from Book store sender application");

            await sender.SendMessageAsync(message);
        }
    }
}
