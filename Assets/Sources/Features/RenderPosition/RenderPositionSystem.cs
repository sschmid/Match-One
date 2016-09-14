using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class RenderPositionSystem : IReactiveSystem {

    public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.Position, CoreMatcher.View).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, 0f), 0.3f);
        }
    }
}
