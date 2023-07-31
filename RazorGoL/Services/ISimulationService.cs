using RazorGoL.Models;

namespace RazorGoL.Services
{
    public interface ISimulationService
    {
        Task<SimulationState> CurrentStateAsync();
        Task<SimulationState> NextStateAsync();
        Task SetStateAsync(InitializeData data);
    }
}
