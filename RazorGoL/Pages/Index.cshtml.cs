using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorGoL.Models;
using RazorGoL.Services;

namespace RazorGoL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISimulationService _simulationService;
        public SimulationState SimulationState { get; set; } = SimulationState.GetDefaultState();

        public IndexModel(ISimulationService simulationService, ILogger<IndexModel> logger)
        {
            _simulationService = simulationService;
            _logger = logger;
        }

        public async Task OnGet()
        {
            SimulationState = await _simulationService.CurrentStateAsync();
        }

        public async Task<IActionResult> OnPostNext()
        {
            SimulationState = await _simulationService.NextStateAsync();

            return Page();
        }
    }
}