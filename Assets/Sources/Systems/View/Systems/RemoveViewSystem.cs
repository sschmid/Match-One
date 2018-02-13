using System.Collections.Generic;
using Entitas;

public sealed class RemoveViewSystem : ReactiveSystem<GameEntity> {

    public RemoveViewSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Destroyed);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isDestroyed && entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            var view = e.view.value;
            view.Unlink();
            view.Hide();
        }
    }
}
