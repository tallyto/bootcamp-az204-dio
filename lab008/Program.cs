// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Messaging.EventGrid;
using System;

public class Program
{
    static string topicEndpoint = "";
    static string topicKey = "";

    public static async Task Main(string[] args)
    {
        Uri endpoint = new Uri(topicEndpoint);

        var credential = new AzureKeyCredential(topicKey);

        var client = new EventGridPublisherClient(endpoint, credential);

        EventGridEvent firstEvent = new EventGridEvent(
            subject: $"Door1",
            eventType: "Azure.Sdk.Sample",
            dataVersion: "1.0",
            data: new
            {
                Name = "Contoso",
                Product = "Widget",
                Price = 34.95
            }
        );

        EventGridEvent secondEvent = new EventGridEvent(
            subject: $"Door2",
            eventType: "Azure.Sdk.Sample",
            dataVersion: "1.0",
            data: new
            {
                Name = "Contoso",
                Product = "Widget",
                Price = 34.95
            }
        );

        await client.SendEventAsync(firstEvent);

        await client.SendEventAsync(secondEvent);

        Console.WriteLine("Events published");

    }
}