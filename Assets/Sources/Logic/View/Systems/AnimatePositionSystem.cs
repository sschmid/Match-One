using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public AnimatePositionSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            Transform transform = e.view.gameObject.transform;
            var pos = e.position;
            float distance = Mathf.Abs(pos.value.y - transform.localPosition.y);
            if (distance <= 0.0f) {
                continue;
            }
            float duration = 0.3f * distance;
            Vector3 destination = new Vector3(pos.value.x, pos.value.y, 0f);
            transform.DOMove(destination, duration)
                .SetEase(Ease.Linear);
        }
    }
}
