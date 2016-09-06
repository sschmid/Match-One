using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        _systems = createSystems(Pools.pool);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool pool) {
        return new Feature("Systems")

            // Input
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
