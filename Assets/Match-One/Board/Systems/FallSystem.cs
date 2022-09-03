using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static GameMatcher;

public sealed class FallSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public FallSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(Destroyed);

    protected override bool Filter(GameEntity entity) => entity.isDestroyed && entity.hasPiece;

    protected override void Execute(List<GameEntity> entities)
    {
        var board = _contexts.game.board.Size;
        for (var x = 0; x < board.x; x++)
        {
            for (var y = 1; y < board.y; y++)
            {
                var position = new Vector2Int(x, y);
                var e = _contexts.game.GetPieceWithPosition(position);
                if (e != null && e.isMovable)
                    MoveDown(e, position);
            }
        }
    }

    void MoveDown(GameEntity e, Vector2Int position)
    {
        var nextRowPos = BoardLogic.GetNextEmptyRow(_contexts, position);
        if (nextRowPos != position.y)
            e.ReplacePosition(new Vector2Int(position.x, nextRowPos));
    }
}
