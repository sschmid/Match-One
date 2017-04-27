public class MatchOneSystems : Feature {

    public MatchOneSystems(Contexts contexts) {

        // Input
        Add(new InputSystems(contexts));

        // Update
        Add(new GameBoardSystems(contexts));
        Add(new GameStateSystems(contexts));

        // Render
        Add(new ViewSystems(contexts));

        // Destroy
        Add(new DestroySystem(contexts));
    }
}
