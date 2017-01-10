using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class ProcessInputSystem : ReactiveSystem {

    readonly Contexts _contexts;

    public ProcessInputSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasInput;
    }

    protected override void Execute(List<Entity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        foreach(var e in _contexts.core.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
            e.isDestroy = true;
        }
    }
}
