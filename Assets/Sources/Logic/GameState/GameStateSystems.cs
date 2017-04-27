public sealed class GameStateSystems : Feature {

    public GameStateSystems(Contexts contexts) {
        Add(new ScoreSystem(contexts));
    }
}
