using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public AnimatePositionSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach(var e in entities) {
            var pos = e.position;
            var isTopRow = pos.y == _context.gameBoard.rows - 1;
            if(isTopRow) {
                e.view.gameObject.transform.localPosition = new Vector3(pos.x, pos.y + 1);
            }
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, 0f), 0.3f);
        }
    }
}
