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

        public async Task<IActionResult> OnPost([FromBody] CellClickEventData data)
        {
            var state = SimulationState = await _simulationService.CurrentStateAsync();
            var aliveCells = new List<int[]>();
            for (int i = 0; i < state.Board.Length; i++)
            {
                for (int j = 0; j < state.Board[i].Length; j++)
                {
                    if (state.Board[i][j] == CellState.Alive)
                        aliveCells.Add(new int[] { i, j });
                }
            }

            var index = aliveCells.FindIndex(item => item[0] == data.Row && item[1] == data.Column);

            if (index == -1)
            {
                aliveCells.Add(new int[] { data.Row, data.Column });
            }
            else
            {
                aliveCells.RemoveAt(index);
            }

            await _simulationService.SetStateAsync(new InitializeData
            {
                Height = state.BoardHeight,
                Width = state.BoardWidth,
                AliveCells = aliveCells.ToArray()
            });

            return new OkObjectResult(new CellClickEventResponse { State = index == -1 ? CellState.Alive : CellState.Dead });
        }
    }
}