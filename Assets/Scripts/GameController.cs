using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.InitState(42);

        var pools = Contexts.sharedInstance;
        pools.SetAllPools();
        pools.AddEntityIndices();

        // Suggested systems lifecycle:
        // systems.Initialize() on Start
        // systems.Execute() on Update
        // systems.Cleanup() on Update after systems.Execute()
        // systems.TearDown() on OnDestroy

        _systems = createSystems(pools);
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
            .Add(new InputSystem(contexts))
            .Add(new ProcessInputSystem(contexts))

            // Update
            .Add(new GameBoardSystem(contexts))
            .Add(new FallSystem(contexts))
            .Add(new FillSystem(contexts))
            .Add(new ScoreSystem(contexts))

            // Render
            .Add(new RemoveViewSystem(contexts))
            .Add(new AddViewSystem(contexts))
            .Add(new AnimatePositionSystem(contexts))

            // Destroy
            .Add(new DestroySystem(contexts));
    }
}
