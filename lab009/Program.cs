using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace MessagePublisher
{
    class Program
    {

        private const string serviceBusConnectionString = "";
        private const string queueName = "";
        private const int numberOfMessages = 10;

        static ServiceBusClient client = default;

        static ServiceBusSender send = default;

        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(serviceBusConnectionString);
            send = client.CreateSender(queueName);

            using ServiceBusMessageBatch messageBatch = await send.CreateMessageBatchAsync();

            for (int i = 1; i <= numberOfMessages; i++)
            {
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    throw new Exception($"The message {i} is too large to fit in the batch.");
                }
            }

            try
            {
                await send.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch of {numberOfMessages} messages has been published to the queue.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await client.DisposeAsync();
                await send.DisposeAsync();
            }


        }


    }
}