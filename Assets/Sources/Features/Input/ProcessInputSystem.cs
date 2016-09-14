using System.Collections.Generic;
using Entitas;

public sealed class ProcessInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.Input.OnEntityAdded(); } }

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Execute(List<Entity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        var e = _pools.core.GetEntityWithPosition(input.x, input.y);
        if(e != null && e.isInteractive) {
            e.isDestroy = true;
        }
    }
}
