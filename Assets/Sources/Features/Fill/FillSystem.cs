using System.Collections.Generic;
using Entitas;

public sealed class FillSystem : ISetPool, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.GameBoardElement.OnEntityRemoved(); } }

    Context _pool;

    public void SetPool(Context pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        var gameBoard = _pool.gameBoard;
        for(int column = 0; column < gameBoard.columns; column++) {
            var nextRowPos = GameBoardLogic.GetNextEmptyRow(_pool, column, gameBoard.rows);
            while(nextRowPos != gameBoard.rows) {
                _pool.CreateRandomPiece(column, nextRowPos);
                nextRowPos = GameBoardLogic.GetNextEmptyRow(_pool, column, gameBoard.rows);
            }
        }
    }
}
