using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

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

    Systems createSystems(Contexts pools) {
        return new Feature("Systems")

            // Input
            .Add(pools.input.CreateSystem(new InputSystem()))
            .Add(pools.input.CreateSystem(new ProcessInputSystem()))

            // Update
            .Add(pools.core.CreateSystem(new GameBoardSystem()))
            .Add(pools.core.CreateSystem(new FallSystem()))
            .Add(pools.core.CreateSystem(new FillSystem()))
            .Add(pools.core.CreateSystem(new ScoreSystem()))

            // Render
            .Add(pools.core.CreateSystem(new RemoveViewSystem()))
            .Add(pools.core.CreateSystem(new AddViewSystem()))
            .Add(pools.core.CreateSystem(new AnimatePositionSystem()))

            // Destroy
            .Add(pools.core.CreateSystem(new DestroySystem()));
    }
}
