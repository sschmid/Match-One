using System.Collections.Generic;
using Entitas;
using static GameMatcher;

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

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(Destroyed);

    protected override bool Filter(GameEntity entity) => entity.isDestroyed && entity.hasPiece;

    protected override void Execute(List<GameEntity> entities)
    {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.Value + entities.Count);
    }
}
