using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        _systems = createSystems(Pools.gamePool);
        _systems.Start();
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
            .Add(pool.CreateSystem<CreateGameBoardSystem>())
            .Add(pool.CreateSystem<CreateGameBoardCacheSystem>())
            .Add(pool.CreateSystem<FallSystem>())
            .Add(pool.CreateSystem<FillSystem>())

            .Add(pool.CreateSystem<ProcessInputSystem>())

            .Add(pool.CreateSystem<RemoveViewSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())

            .Add(pool.CreateSystem<DestroySystem>())
            .Add(pool.CreateSystem<ScoreSystem>());
    }
}
