using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.InitState(42);

        var contexts = Contexts.sharedInstance;

        _systems = new MatchOneSystems(contexts);

        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    void OnDestroy() {
        _systems.TearDown();
    }
}
