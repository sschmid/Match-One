using Entitas;

public class ProcessInputSystem : IStartSystem, IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Input;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    Pool _pool;
    GameBoardCacheComponent _gameBoardCache;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        _gameBoardCache = _pool.gameBoardCache;
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("ProcessInputSystem");

        var input = entities.SingleEntity().input;
        var e = _gameBoardCache.grid[input.x, input.y];
        e.isDestroy = true;
    }
}

