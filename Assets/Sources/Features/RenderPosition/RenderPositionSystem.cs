using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(Matcher.Position, Matcher.View).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {

        Debug.Log("Render Position");

        foreach (var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, 0f), 0.3f);
        }
    }
}

