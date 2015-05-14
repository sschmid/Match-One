using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Resource;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityRemoved;
    }

    public void SetPool(Pool pool) {
        pool.GetGroup(Matcher.View).OnEntityWillBeRemoved += onEntityWillBeRemoved;
    }

    void onEntityWillBeRemoved(Group group, Entity entity) {
        Object.Destroy(entity.view.gameObject);
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("RemoveViewSystem");

        foreach (var e in entities) {
            if (e.hasView) {
                e.RemoveView();
            }
        }
    }
}
