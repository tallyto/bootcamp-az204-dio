using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace lab007
{
    public class FileParser
    {
        private readonly ILogger<FileParser> _logger;

        public FileParser(ILogger<FileParser> logger)
        {
            _logger = logger;
        }

        [Function("FileParser")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string? connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                await response.WriteStringAsync("StorageConnectionString is not set");
                return response;
            }

            BlobClient blob = new(connectionString, "drop", "records.json");

            BlobDownloadResult downloadResult = blob.DownloadContent();

            await response.WriteStringAsync(downloadResult.Content.ToString());

            return response;
        }
    }
}
