using Entitas;

public sealed class GameStateSystems : Feature {

    public GameStateSystems(Contexts contexts) : base("GameState Systems") {
        Add(new ScoreSystem(contexts));
    }
}