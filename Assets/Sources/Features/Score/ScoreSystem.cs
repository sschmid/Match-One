using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem, IInitializeSystem {

    readonly Contexts _contexts;

    public ScoreSystem(Contexts contexts) : base(contexts.core) {
        _contexts = contexts;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    public void Initialize() {
        _contexts.score.SetScore(0);
    }

    protected override void Execute(List<Entity> entities) {
        _contexts.score.ReplaceScore(_contexts.score.score.value + entities.Count);
    }
}
