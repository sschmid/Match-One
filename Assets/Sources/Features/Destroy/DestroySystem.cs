using Entitas;

public class DestroySystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return Matcher.Destroy; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("Destroy");

        foreach (var e in entities) {
            _pool.DestroyEntity(e);
        }
    }
}

