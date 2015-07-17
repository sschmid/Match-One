using Entitas;
using UnityEngine;
using DG.Tweening;

public class RenderPositionSystem : IReactiveSystem {
    public IMatcher trigger { get { return Matcher.AllOf(Matcher.Position, Matcher.View); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    public void Execute(Entity[] entities) {

        Debug.Log("Render Position");

        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, 0f), 0.3f);
        }
    }
}

