using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        Random.seed = 42;

        var pools = Pools.sharedInstance;
        pools.SetAllPools();

        pools.AddEntityIndices();

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
