using Entitas;
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
        var systems = new Systems();
        systems.Add(pool.CreateSystem<CreateGameBoardSystem>());
        systems.Add(pool.CreateSystem<CreateGameBoardCacheSystem>());
        systems.Add(pool.CreateSystem<FillGameBoardSystem>());

        systems.Add(pool.CreateSystem<RemoveViewSystem>());
        systems.Add(pool.CreateSystem<AddViewSystem>());
        systems.Add(pool.CreateSystem<RenderPositionSystem>());

        systems.Add(pool.CreateSystem<ProcessInputSystem>());
        systems.Add(pool.CreateSystem<DestroySystem>());

        systems.Add(pool.CreateSystem<ScoreSystem>());
        return systems;
    }
}
