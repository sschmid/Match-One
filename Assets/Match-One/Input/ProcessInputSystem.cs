﻿using System.Collections.Generic;
using Entitas;
using static InputMatcher;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    readonly Contexts _contexts;

    public ProcessInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
        context.CreateCollector(Input);

    protected override bool Filter(InputEntity entity) => entity.hasInput;

    protected override void Execute(List<InputEntity> entities)
    {
        var e = _contexts.game.GetPieceWithPosition(_contexts.input.input.Value);
        if (e != null && e.isInteractive)
            e.isDestroyed = true;
    }
}
