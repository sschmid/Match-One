using System.Collections.Generic;
using Entitas;

public sealed class FillSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public FillSystem(Contexts contexts) : base(contexts.game) {
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
            var nextRowPos = GameBoardLogic.GetNextEmptyRow(_context, column, gameBoard.rows);
            while(nextRowPos != gameBoard.rows) {
                _context.CreateRandomPiece(column, nextRowPos);
                nextRowPos = GameBoardLogic.GetNextEmptyRow(_context, column, gameBoard.rows);
            }
        }
    }
}
