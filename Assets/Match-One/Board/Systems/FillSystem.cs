using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static GameMatcher;

public sealed class FillSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public FillSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(Destroyed);

    protected override bool Filter(GameEntity entity) => entity.isDestroyed && entity.isPiece;

    protected override void Execute(List<GameEntity> entities)
    {
        var board = _contexts.game.board.Value;
        for (var x = 0; x < board.x; x++)
        {
            var position = new Vector2Int(x, board.y);
            var nextRowPos = BoardLogic.GetNextEmptyRow(_contexts, position);
            while (nextRowPos != board.y)
            {
                _contexts.game.CreateRandomPiece(x, nextRowPos);
                nextRowPos = BoardLogic.GetNextEmptyRow(_contexts, position);
            }
        }
    }
}
