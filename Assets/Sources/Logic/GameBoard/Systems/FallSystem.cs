using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class FallSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = _context.gameBoard;
        for(int column = 0; column < gameBoard.columns; column++) {
            for(int row = 1; row < gameBoard.rows; row++) {
                var movables = _context.GetEntitiesWithPosition(column, row)
                                    .Where(e => e.isMovable)
                                    .ToArray();

                foreach(var e in movables) {
                    moveDown(e, column, row);
                }
            }
        }
    }

    void moveDown(GameEntity e, int column, int row) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_context, column, row);
        if(nextRowPos != row) {
            e.ReplacePosition(column, nextRowPos);
        }
    }
}
