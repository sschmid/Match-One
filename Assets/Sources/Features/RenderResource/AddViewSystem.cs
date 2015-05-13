using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public IMatcher GetTriggeringMatcher() {
        return GameMatcher.Resource;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(Entity[] entities) {
        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            var gameObject = Object.Instantiate(res);
            gameObject.transform.SetParent(_viewContainer, false);
            e.AddView(gameObject);
        }
    }
}