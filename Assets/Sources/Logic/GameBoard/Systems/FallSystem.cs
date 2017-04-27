using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class FallSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = _context.gameBoard;
        for (int column = 0; column < gameBoard.columns; column++) {
            for (int row = 1; row < gameBoard.rows; row++) {
                var position = new IntVector2(column, row);
                var movables = _context.GetEntitiesWithPosition(position)
                                    .Where(e => e.isMovable)
                                    .ToArray();

                foreach (var e in movables) {
                    moveDown(e, position);
                }
            }
        }
    }

    void moveDown(GameEntity e, IntVector2 position) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_context, position);
        if (nextRowPos != position.y) {
            e.ReplacePosition(new IntVector2(position.x, nextRowPos));
        }
    }
}
