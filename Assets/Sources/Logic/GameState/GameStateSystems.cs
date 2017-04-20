using Entitas;

public sealed class GameStateSystems : Feature {

    public GameStateSystems(Contexts contexts) : base() {
        Add(new ScoreSystem(contexts));
    }
}
