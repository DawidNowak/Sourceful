using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Sourceful - Artwork grpc demo\n");

            var channel = GrpcChannel.ForAddress("https://localhost:61877");
            var client = new Artwork.ArtworkClient(channel);

            var createArtworkRequest = new CreateArtworkRequestModel
            {
                GalleryId = "5E9ABDB5-E4B8-4880-9BAF-7089D75DB294",
                Name = "Portrait of Joseph Roulin",
                Creator = "Vincent van Gogh",
                Price = 58000000,
                CurrencyIsoCode = "USD"
            };

            var reply = await client.CreateArtworkAsync(createArtworkRequest);

            Console.WriteLine($"Artwork ({reply.Id}) added succesfully");

            Console.WriteLine();
        }
    }
}
