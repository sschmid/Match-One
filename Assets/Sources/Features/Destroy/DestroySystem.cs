using System.Collections.Generic;
using Entitas;

public sealed class DestroySystem : ReactiveSystem {

    readonly Context _context;

    public DestroySystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(Entity entity) {
        return entity.isDestroy;
    }

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            _context.DestroyEntity(e);
        }
    }
}
