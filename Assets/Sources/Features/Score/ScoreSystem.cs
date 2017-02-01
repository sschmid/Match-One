using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem {

    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    public void Initialize() {
        _contexts.gameState.SetScore(0);
    }

    protected override void Execute(List<GameEntity> entities) {
        _contexts.gameState.ReplaceScore(_contexts.gameState.score.value + entities.Count);
    }
}
