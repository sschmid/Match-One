using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        _systems = createSystems(Pools.pool);
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
            .Add(pool.CreateGameBoardSystem())
            .Add(pool.CreateCreateGameBoardCacheSystem())
            .Add(pool.CreateFallSystem())
            .Add(pool.CreateFillSystem())

            .Add(pool.CreateProcessInputSystem())

            .Add(pool.CreateRemoveViewSystem())
            .Add(pool.CreateAddViewSystem())
            .Add(pool.CreateRenderPositionSystem())

            .Add(pool.CreateDestroySystem())
            .Add(pool.CreateScoreSystem());
    }
}
