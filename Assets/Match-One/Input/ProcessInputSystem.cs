using System.Collections.Generic;
using Entitas;

public sealed class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    readonly Contexts _contexts;

    public ProcessInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        => context.CreateCollector(InputMatcher.Input);

    protected override bool Filter(InputEntity entity) => entity.hasInput;

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        var e = _contexts.game.GetPieceWithPosition(input.value);
        if (e != null && e.isInteractive)
        {
            e.isDestroyed = true;
        }
    }
}
