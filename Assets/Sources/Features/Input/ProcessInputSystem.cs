using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class ProcessInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.Input.OnEntityAdded(); } }

    Contexts _pools;

    public void SetPools(Contexts pools) {
        _pools = pools;
    }

    public void Execute(List<Entity> entities) {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        foreach(var e in _pools.core.GetEntitiesWithPosition(input.x, input.y).Where(e => e.isInteractive)) {
            e.isDestroy = true;
        }
    }
}
