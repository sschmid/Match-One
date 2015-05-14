using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem {
    public IMatcher GetTriggeringMatcher() {
        return Matcher.AllOf(GameMatcher.Position, GameMatcher.View);
    }

    public GroupEventType GetEventType() {
        return GroupEventType.OnEntityAdded;
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("RenderPositionSystem");

        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.position = new Vector3(pos.x, pos.y, 0f);
        }
    }
}

