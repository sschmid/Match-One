using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem {

    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    public void Initialize() {
        _contexts.gameState.SetScore(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return !entity.isGameBoardElement;
    }

    protected override void Execute(List<GameEntity> entities) {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + entities.Count);
    }
}
