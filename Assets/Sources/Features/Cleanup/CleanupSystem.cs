using Entitas;

public class CleanupSystem : IExecuteSystem, ISetPool {

    Pool _pool;
    Group _input;

    public void SetPool(Pool pool) {
        _pool = pool;
        _input = pool.GetGroup(Matcher.Input);
    }

    public void Execute() {
        foreach (var e in _input.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}

