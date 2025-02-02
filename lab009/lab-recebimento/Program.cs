using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;

namespace MessageReader
{
    class Program
    {
        static string serviceBusConnectionString = "";

        static string queueName = "";

        static ServiceBusClient client = default;

        static ServiceBusProcessor processor = default;


        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");
            await args.CompleteMessageAsync(args.Message);
        }

        static async Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            await Task.CompletedTask;
        }

        static async Task Main(string[] args)
        {
            try
            {
                client = new ServiceBusClient(serviceBusConnectionString);

                processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;

                await processor.StartProcessingAsync();

                Console.WriteLine("Press any key to end the session");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                await processor.StopProcessingAsync();
                await client.DisposeAsync();
            }

        }
    }
}