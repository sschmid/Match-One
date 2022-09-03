using System;
using Entitas;

/**
 *
 * The GameController creates and manages all systems in Match One
 *
 */

public class GameController
{
    readonly Systems _systems;

    public GameController(Contexts contexts, IGameConfig gameConfig)
    {
        var random = new Random(DateTime.UtcNow.Millisecond);
        UnityEngine.Random.InitState(random.Next());
        Rand.game = new Rand(random.Next());

        contexts.config.SetGameConfig(gameConfig);

        // This is the heart of Match One:
        // All logic is contained in all the sub systems of GameSystems
        _systems = new GameSystems(contexts);
    }

    public void Initialize()
    {
        // This calls Initialize() on all sub systems
        _systems.Initialize();
    }

    public void Execute()
    {
        // This calls Execute() and Cleanup() on all sub systems
        _systems.Execute();
        _systems.Cleanup();
    }
}
