public class GameSystems : Feature {

    public GameSystems(Contexts contexts) {

        // Input
        Add(new InputSystems(contexts));

        // Update
        Add(new GameBoardSystems(contexts));
        Add(new ScoreSystem(contexts));

        // Render
        Add(new ViewSystems(contexts));
        Add(new EventSystems(contexts));

        // Destroy
        Add(new DestroyEntitySystem(contexts));
    }
}
