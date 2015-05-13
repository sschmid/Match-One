using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return GameMatcher.Resource;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityRemoved;
    }

    public void SetPool(Pool pool) {
        pool.GetGroup(GameMatcher.View).OnEntityWillBeRemoved += onEntityWillBeRemoved;
    }

    void onEntityWillBeRemoved(Group group, Entity entity) {
        Object.Destroy(entity.view.gameObject);
    }

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            if (e.hasView) {
                e.RemoveView();
            }
        }
    }
}
