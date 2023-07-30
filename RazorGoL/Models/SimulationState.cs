namespace RazorGoL.Models
{
    public class SimulationState
    {
        private const int defaultDimension = 21;

        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

        public CellState[][] Board { get; set; } = null!;

        public static SimulationState GetDefaultState()
        {
            var state = new SimulationState
            {
                BoardHeight = defaultDimension,
                BoardWidth = defaultDimension,
                Board = new CellState[defaultDimension][]
            };

            for (int i = 0; i < defaultDimension; i++)
            {
                state.Board[i] = new CellState[defaultDimension];
            }

            return state;
        }
    }
}
