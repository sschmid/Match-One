using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.Resource;
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("AddViewSystem");

        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            var gameObject = Object.Instantiate(res);
            gameObject.transform.SetParent(_viewContainer, false);
            e.AddView(gameObject);

            if (e.hasPosition) {
                var pos = e.position;
                gameObject.transform.position = new Vector3(pos.x, pos.y + 1, 0f);
            }
        }
    }
}