using Entitas;
using Entitas.Unity.VisualDebugging;
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
        #if (UNITY_EDITOR)
        return new DebugSystems()
        #else
        return new Systems()
        #endif

            // Input
            .Add(pool.CreateSystem<ProcessInputSystem>())

            // Update
            .Add(pool.CreateSystem<CreateGameBoardCacheSystem>())
            .Add(pool.CreateSystem<GameBoardSystem>())
            .Add(pool.CreateSystem<FallSystem>())
            .Add(pool.CreateSystem<FillSystem>())
            .Add(pool.CreateSystem<ScoreSystem>())

            // Render
            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())

            // Destroy
            .Add(pool.CreateSystem<DestroySystem>());
    }
}
