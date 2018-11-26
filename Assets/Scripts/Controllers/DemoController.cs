using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    Systems _systems;

    void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new DemoFeatures(contexts);
        _systems = new DemoFeatures(contexts);
        _systems = new DemoFeatures(contexts);

        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    void OnDestroy()
    {
        _systems.TearDown();
    }
}

public sealed class DemoFeatures : Feature
{
    public DemoFeatures(Contexts contexts)
    {
        Add(new DemoSystem(contexts));
        Add(new DemoReactiveSystem(contexts));
        Add(new GameEventSystems(contexts));
        Add(new GameStateEventSystems(contexts));
    }
}

public sealed class DemoReactiveSystem : ReactiveSystem<GameStateEntity>
{
    public DemoReactiveSystem(Contexts contexts) : base(contexts.gameState)
    {
        var g = contexts.game.GetGroup(GameMatcher.Position);
        g.GetSingleEntity();
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector(GameStateMatcher.Score);
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return entity.hasScore;
    }

    protected override void Execute(List<GameStateEntity> entities)
    {
        UnityEngine.Debug.Log("entities.SingleEntity().score.value: " + entities.SingleEntity().score.value);
    }
}

public sealed class DemoSystem : IInitializeSystem, IExecuteSystem
{
    readonly Contexts _contexts;

    public DemoSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.gameState.SetScore(0);
    }

    public void Execute()
    {
        _contexts.gameState.ReplaceScore(
            _contexts.gameState.score.value + 1
        );
    }
}

public sealed class TickComponent : IComponent
{
    public int value;
}
