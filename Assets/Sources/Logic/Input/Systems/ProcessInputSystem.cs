using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity> {

    readonly Contexts _contexts;

    public ProcessInputSystem(Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
    }

    protected override Collector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity) {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        foreach(var e in _contexts.game.GetEntitiesWithPosition(new IntVector2(input.x, input.y)).Where(e => e.isInteractive)) {
            e.isDestroyed = true;
        }
    }
}
