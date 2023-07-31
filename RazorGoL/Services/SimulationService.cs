using RazorGoL.Models;

namespace RazorGoL.Services
{
    public class SimulationService : ISimulationService, IDisposable
    {
        private readonly HttpClient _client;
        private readonly ILogger<SimulationService> _logger;

        public SimulationService(ILogger<SimulationService> logger)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5103/api/simulation/");
            _logger = logger;
        }

        public async Task<SimulationState> CurrentStateAsync()
        {
            var response = await _client.GetAsync("current");
            return (await response.Content.ReadFromJsonAsync<SimulationState>())!;
        }

        public async Task<SimulationState> NextStateAsync()
        {
            var response = await _client.GetAsync("next");
            return (await response.Content.ReadFromJsonAsync<SimulationState>())!;
        }

        public async Task SetStateAsync(InitializeData data)
        {
           var response = await _client.PostAsJsonAsync("initialize", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Error initializing state: {error}", response.StatusCode);
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
