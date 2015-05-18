using System.Linq;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    IStartSystem[] _startSystems;
    IExecuteSystem[] _executeSystems;

    void Start() {
        Random.seed = 42;

        createSystems(Pools.gamePool);

        foreach (var system in _startSystems) {
            system.Start();
        }
    }

    void Update() {
        foreach (var system in _executeSystems) {
            system.Execute();
        }
    }

    void createSystems(Pool pool) {
        var systems = new [] {
            pool.CreateSystem<CreateGameBoardSystem>(),
            pool.CreateSystem<CreateGameBoardCacheSystem>(),
            pool.CreateSystem<FillGameBoardSystem>(),

            pool.CreateSystem<RemoveViewSystem>(),
            pool.CreateSystem<AddViewSystem>(),
            pool.CreateSystem<RenderPositionSystem>(),

            pool.CreateSystem<ProcessInputSystem>(),

            pool.CreateSystem<DestroySystem>(),
            pool.CreateSystem<ScoreSystem>()
        };

        _startSystems = systems
            .Select(system => {
                var reactiveSystem = system as ReactiveSystem;
                return reactiveSystem != null ? reactiveSystem.subsystem : system;})
            .OfType<IStartSystem>().ToArray();

        _executeSystems = systems.OfType<IExecuteSystem>().ToArray();
    }
}
