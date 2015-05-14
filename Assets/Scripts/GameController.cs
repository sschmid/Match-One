using System.Linq;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour {

    IStartSystem[] _startSystems;
    IExecuteSystem[] _executeSystems;

    void Start() {
        Random.seed = 42;

        var pool = createPool();
        createSystems(pool);

        foreach (var system in _startSystems) {
            system.Start();
        }
    }

    void Update() {
        foreach (var system in _executeSystems) {
            system.Execute();
        }
    }

    Pool createPool() {
        #if (UNITY_EDITOR)
        return new DebugPool(GameComponentIds.TotalComponents, "Game Pool");
        #else
        return new Pool(GameComponentIds.TotalComponents);
        #endif
    }

    void createSystems(Pool pool) {
        var systems = new [] {
            pool.CreateSystem<CreateGameBoardSystem>(),
            pool.CreateSystem<CreateGameBoardCacheSystem>(),

            pool.CreateSystem<FillGameBoardSystem>(),

            pool.CreateSystem<RemoveViewSystem>(),
            pool.CreateSystem<AddViewSystem>(),
            pool.CreateSystem<RenderPositionSystem>()
        };

        _startSystems = systems
            .Select(system => {
                var reactiveSystem = system as ReactiveSystem;
                return reactiveSystem != null ? reactiveSystem.subsystem : system;})
            .OfType<IStartSystem>().ToArray();

        _executeSystems = systems.OfType<IExecuteSystem>().ToArray();
    }
}
