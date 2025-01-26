using Newtonsoft.Json;
using System.Text;

namespace Vehicle.Ping.Simulator
{
    public class Worker : BackgroundService
    {
        private readonly HttpClient client;
        private const string requestUrl = "http://localhost:5220/Vehicle/ping";

        private readonly List<Vehicle> vehicles;
        //private readonly List<string> vehicles = 
        //    ["YS2R4X20005399401", "VLUR4X20009093588", "VLUR4X20009048066", "YS2R4X20005388011", "YS2R4X20005387949", "YS2R4X20005387765", "YS2R4X20005387055"];

        public Worker(HttpClient client)
        {
            this.client = client;

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5220/Vehicle");

            using (client = new HttpClient())
            {
                var httpResponseMessage = client.Send(httpRequestMessage);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    var httpContent = httpResponseMessage.Content;
                    var errorResponse = httpContent != null
                        ? httpResponseMessage.Content.ReadAsStringAsync().Result
                        : string.Empty;

                    Console.WriteLine(errorResponse);
                }

                var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(response);

                vehicles = result!.ToList();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    var connectionStatus = GenerateRandomPingStatus();
                    await PingAsync(connectionStatus, vehicle.VehicleId).ConfigureAwait(false);

                    Console.WriteLine($"{vehicle.VehicleId} {DateTime.Now.ToString()} status : {connectionStatus}");
                }

                await Task.Delay(60000);
            }
        }

        private async Task PingAsync(bool connectionStatus, string vehicleId)
        {
            var httpStringContent = new StringContent("{\r\n  \"vehicleId\": \"" + vehicleId + "\",\r\n  \"connectionStatus\": " + connectionStatus.ToString().ToLower() + "\r\n}", Encoding.UTF8, "application/json");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = httpStringContent
            };

            using (var client = new HttpClient())
            {
                var httpResponseMessage = await client.SendAsync(httpRequestMessage).ConfigureAwait(false);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    var httpContent1 = httpResponseMessage.Content;
                    var errorResponse = httpContent1 != null
                        ? await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                        : string.Empty;

                    Console.WriteLine(errorResponse);
                }
            }
        }

        private static bool GenerateRandomPingStatus()
        {
            Random randGen = new Random();
            var trueChance = 80;

            int ping = randGen.Next(0, 100) < trueChance ? 1 : 0;

            return ping > 0;
        }
    }
}
