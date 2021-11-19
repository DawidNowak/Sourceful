using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        private const string AmfiladaGalleryId = "5E9ABDB5-E4B8-4880-9BAF-7089D75DB294";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Sourceful - Artwork grpc demo\n");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Artwork.ArtworkClient(channel);

            await GetArtworks(client);
            await AddNetAwtwork(client);
            await GetArtworks(client);

            Console.ReadLine();
        }

        private static async Task GetArtworks(Artwork.ArtworkClient client)
        {
            WriteSeparator("Get Art Gallery Artworks");

            var getArtworksQuery = new GetArtworksByArtGalleryIdModel
            {
                GalleryId = AmfiladaGalleryId
            };

            using (var call = client.GetArtworksByArtGalleryId(getArtworksQuery))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    Console.WriteLine(ArtworkDescription(call.ResponseStream.Current));
                }
            }
        }

        private static async Task AddNetAwtwork(Artwork.ArtworkClient client)
        {
            WriteSeparator("Adding new artwork");

            var createArtworkRequest = new CreateArtworkRequestModel
            {
                GalleryId = AmfiladaGalleryId,
                Name = "Portrait of Joseph Roulin",
                Creator = "Vincent van Gogh",
                Price = 58000000,
                CurrencyIsoCode = "USD"
            };

            var reply = await client.CreateArtworkAsync(createArtworkRequest);

            Console.WriteLine($"Artwork ({reply.Id}) added succesfully");
        }

        private static void WriteSeparator(string text)
        {
            var separator = new string('*', text.Length);

            Console.WriteLine($"\n{separator}\n{text.ToUpper()}\n{separator}");
        }

        private static string ArtworkDescription(ArtworkResponse artwork)
        {
            return $"{artwork.Name}, {artwork.Creator} {artwork.Created}, {artwork.Price} {(artwork.IsReserved ? "Reserved" : "")} {(artwork.IsSold ? "Sold" : "")}";
        }
    }
}
