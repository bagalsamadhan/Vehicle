using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;

namespace Vehicle.Ping.Simulator
{
    public class Worker(IHttpClientFactory httpClientFactory) : BackgroundService
    {
        private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
        private static readonly Random _randGen = new();
        private const string baseUrl = "http://localhost:5220/Vehicle";
        private const string pingUrl = "http://localhost:5220/Vehicle/ping";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var vehicles = await InitializeVehicles();

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var (vehicle, connectionStatus) in from Vehicle vehicle in vehicles
                                                            let connectionStatus = GenerateRandomPingStatus()
                                                            select (vehicle, connectionStatus))
                {
                    await PingAsync(connectionStatus, vehicle.VehicleId);

                    Console.WriteLine($"{vehicle.VehicleId} {DateTime.Now.ToString()} status : {connectionStatus}");
                }

                // Ping after a minute
                await Task.Delay(60000, stoppingToken);
            }
        }

        private async Task<List<Vehicle>> InitializeVehicles()
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);

                var httpClient = this.httpClientFactory.CreateClient();

                var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                // Check if call was successfull 
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Initializing vehicles failed : {await response.Content.ReadAsStringAsync()}");
                }

                // read the contents as a string
                var result = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(result))
                {
                    return default!;
                }

                // deserialize the response to a type
                var vehicleResult = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(result);

                return vehicleResult!.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing vehicles: {ex.Message}");
                throw;
            }
        }

        private async Task PingAsync(bool connectionStatus, string vehicleId)
        {
            var payload = new { vehicleId, connectionStatus };

            var stringContent = new StringContent(JsonConvert.SerializeObject(payload), System.Text.Encoding.UTF8, "application/json");

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, pingUrl)
                {
                    Content = stringContent
                };

                var httpClient = this.httpClientFactory.CreateClient();
                var response = await httpClient.SendAsync(request);

                // Check if call was successfull 
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Ping failed: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending ping: {ex.Message}");
                throw;
            }
        }

        private static bool GenerateRandomPingStatus()
        {
            return _randGen.Next(0, 100) < 80;
        }
    }
}