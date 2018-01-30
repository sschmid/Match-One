using System.Collections.Generic;
using Entitas;

public sealed class FillSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public FillSystem(Contexts contexts) : base(contexts.game) {
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
        int rows = gameBoard.rows;
        var position = new IntVector2(0, rows);
        for (int column = 0; column < gameBoard.columns; column++) {
            position.x = column;
            int nextRowPos = GameBoardLogic.GetNextEmptyRow(_context, position);
            int numSpawns = rows - nextRowPos;
            for (int spawnRow = rows, spawnEnd = rows + numSpawns;
                    spawnRow < spawnEnd; ++spawnRow) {
                _context.CreateRandomPiece(column, spawnRow);
            }
        }
    }
}
