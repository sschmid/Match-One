using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class FallSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public FallSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Destroyed);

    protected override bool Filter(GameEntity entity) => entity.isDestroyed && entity.isPiece;

    protected override void Execute(List<GameEntity> entities)
    {
        var board = _contexts.game.board.value;
        for (int x = 0; x < board.x; x++)
        {
            for (int y = 1; y < board.y; y++)
            {
                var position = new Vector2Int(x, y);
                var e = _contexts.game.GetPieceWithPosition(position);
                if (e != null && e.isMovable)
                {
                    moveDown(e, position);
                }
            }
        }
    }

    void moveDown(GameEntity e, Vector2Int position)
    {
        var nextRowPos = BoardLogic.GetNextEmptyRow(_contexts, position);
        if (nextRowPos != position.y)
        {
            e.ReplacePosition(new Vector2Int(position.x, nextRowPos));
        }
    }
}
