using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        var pools = Pools.sharedInstance;
        pools.SetAllPools();

        // Manually add entity indices.
        // It's planned to generate this in future versions of Entitas
        pools.AddEntityIndices();

        // Recommended systems lifecycle:
        // systems.Initialize() on Start
        // systems.Execute() on Update
        // systems.Cleanup() on Update
        // systems.Deinitialize() on OnDestroy

        _systems = createSystems(pools);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    void OnDestroy() {
        _systems.Deinitialize();
    }

    Systems createSystems(Pools pools) {
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
            .Add(pools.core.CreateSystem(new RenderPositionSystem()))

            // Destroy
            .Add(pools.core.CreateSystem(new DestroySystem()));
    }
}
