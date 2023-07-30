using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorGoL.Models;

namespace RazorGoL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SimulationState SimulationState { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            SimulationState = SimulationState.GetDefaultState();
        }

        public void OnGet()
        {

        }
    }
}