using Entitas;

public class ProcessInputSystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Input;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("Process Input");

        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        var e = _pool.gameBoardCache.grid[input.x, input.y];
        if (e != null && e.isInteractive) {
            e.isDestroy = true;
        }

        _pool.DestroyEntity(inputEntity);
    }
}

