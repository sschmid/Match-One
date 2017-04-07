using Entitas;
using UnityEngine;
using Entitas.Blueprints.Unity;

public class GameController : MonoBehaviour {

    public Blueprints blueprints;

    Systems _systems;

    void Start() {
        Random.InitState(42);

        var contexts = Contexts.sharedInstance;
        contexts.game.SetBlueprints(blueprints);

        // Suggested systems lifecycle:
        // systems.Initialize() on Start
        // systems.Execute() on Update
        // systems.Cleanup() on Update after systems.Execute()
        // systems.TearDown() on OnDestroy

        _systems = createSystems(contexts);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    void OnDestroy() {
        _systems.TearDown();
    }

    Systems createSystems(Contexts contexts) {
        return new Feature("Systems")

            // Input
            .Add(new InputSystems(contexts))

            // Update
            .Add(new GameBoardSystems(contexts))
            .Add(new GameStateSystems(contexts))

            // Render
            .Add(new ViewSystems(contexts))

            // Destroy
            .Add(new DestroySystem(contexts));
    }
}
