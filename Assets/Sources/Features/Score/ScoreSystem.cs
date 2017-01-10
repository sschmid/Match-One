using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem, IInitializeSystem {

    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    public void Initialize() {
        _contexts.gameSession.SetScore(0);
    }

    protected override void Execute(List<Entity> entities) {
        _contexts.gameSession.ReplaceScore(_contexts.gameSession.score.value + entities.Count);
    }
}
