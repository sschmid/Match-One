using Entitas.Unity;

namespace MatchOne
{
    public sealed class GameSystems : Feature
    {
        public GameSystems(
            GameContext gameContext,
            GameStateContext gameStateContext,
            InputContext inputContext,
            ConfigContext configContext)
        {
            // Input
            Add(new ProcessInputSystem(gameContext, inputContext));

            // Update
            Add(new BoardSystem(gameContext, configContext));
            Add(new FallSystem(gameContext));
            Add(new FillSystem(gameContext));
            Add(new ScoreSystem(gameContext, gameStateContext));

            // View
            Add(new AddViewSystem(gameContext));

            // Events (Generated)
            Add(configContext.CreateEventSystems());
            Add(inputContext.CreateEventSystems());
            Add(gameContext.CreateEventSystems());
            Add(gameStateContext.CreateEventSystems());

            // Cleanup (Generated)
            Add(configContext.CreateCleanupSystems());
            Add(inputContext.CreateCleanupSystems());
            Add(gameContext.CreateCleanupSystems());
            Add(gameStateContext.CreateCleanupSystems());
        }
    }
}
