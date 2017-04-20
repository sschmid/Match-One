using Entitas;

public sealed class GameBoardSystems : Feature {

    public GameBoardSystems(Contexts contexts) : base("GameBoard Systems") {
        Add(new GameBoardSystem(contexts));
        Add(new FallSystem(contexts));
        Add(new FillSystem(contexts));
    }
}
