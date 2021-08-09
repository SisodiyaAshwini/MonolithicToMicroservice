using Azure.Messaging.ServiceBus;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Product.BookStore.MessageReceiver
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

            // The receiver is responsible for reading messages from the queue.
            ServiceBusReceiver receiver = client.CreateReceiver(queue);
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);
        }
    }
}
