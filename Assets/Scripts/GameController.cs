using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Services.singleton.Initialize(this);
        _systems = new GameSystems(Contexts.sharedInstance);
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
