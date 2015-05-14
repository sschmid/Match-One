using Entitas;

public class DestroySystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Destroy;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("DestroySystem");

        foreach (var e in entities) {
            _pool.DestroyEntity(e);
        }
    }
}

