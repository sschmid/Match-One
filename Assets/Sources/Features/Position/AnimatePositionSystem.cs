using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem {

    public AnimatePositionSystem(Contexts contexts) : base(contexts.core) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.Position);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var pos = e.position;
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, 0f), 0.3f);
        }
    }
}
