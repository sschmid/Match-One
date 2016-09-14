using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        var pools = Pools.sharedInstance;
        pools.SetAllPools();

        _systems = createSystems(pools.pool);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    void OnDestroy() {
        _systems.Deinitialize();
    }

    Systems createSystems(Pool pool) {
        return new Feature("Systems")

            // Input
            .Add(pool.CreateSystem(new InputSystem()))
            .Add(pool.CreateSystem(new ProcessInputSystem()))

            // Update
            .Add(pool.CreateSystem(new CreateGameBoardCacheSystem()))
            .Add(pool.CreateSystem(new GameBoardSystem()))
            .Add(pool.CreateSystem(new FallSystem()))
            .Add(pool.CreateSystem(new FillSystem()))
            .Add(pool.CreateSystem(new ScoreSystem()))

            // Render
            .Add(pool.CreateSystem(new RemoveViewSystem()))
            .Add(pool.CreateSystem(new AddViewSystem()))
            .Add(pool.CreateSystem(new RenderPositionSystem()))

            // Destroy
            .Add(pool.CreateSystem(new DestroySystem()));
    }
}
