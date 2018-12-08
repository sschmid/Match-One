using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.gameState.SetScore(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Destroyed);

    protected override bool Filter(GameEntity entity) => entity.isDestroyed && entity.isPiece;

    protected override void Execute(List<GameEntity> entities)
    {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + entities.Count);
    }
}
