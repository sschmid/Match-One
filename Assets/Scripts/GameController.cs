using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour {

    IExecuteSystem[] _systems;

    void Start() {
        Random.seed = 42;
        var pool = createPool();
        _systems = createSystem(pool);



        var e = pool.CreateEntity();
        e.AddResource(Res.Piece0);



    }

    Pool createPool() {
        #if (UNITY_EDITOR)
        return new DebugPool(GameComponentIds.TotalComponents, "Game Pool");
        #else
        return new Pool(GameComponentIds.TotalComponents);
        #endif
    }

    IExecuteSystem[] createSystem(Pool pool) {
        return new [] {
            pool.CreateExecuteSystem<RemoveViewSystem>(),
            pool.CreateExecuteSystem<AddViewSystem>()
        };
    }

    void Update() {
        foreach (var system in _systems) {
            system.Execute();
        }
    }
}
