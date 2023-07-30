using RazorGoL.Models;

namespace RazorGoL.Services
{
    public class SimulationService : ISimulationService, IDisposable
    {
        private readonly HttpClient _client;

        public SimulationService() 
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5103/api/simulation/");
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

        public Task SetStateAsync(SimulationState state)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
