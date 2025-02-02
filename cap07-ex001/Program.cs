using System.ComponentModel;
using Azure.Messaging.ServiceBus;


string connectionString = "";

string queueName = "";

var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender(queueName);

using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (int i = 0; i < 3; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}

try
{
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of 3 messages has been published to the queue.");
}
finally
{
    await sender.DisposeAsync();
}

ServiceBusProcessor processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

try 
{
    processor.ProcessMessageAsync +=  MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();

    Console.WriteLine("Wait for a minute and then press any key to end the processing");
    Console.ReadKey();
}
finally
{
    await processor.DisposeAsync();
    await client.DisposeAsync();
}

static async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");

    await args.CompleteMessageAsync(args.Message);
}

static Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}