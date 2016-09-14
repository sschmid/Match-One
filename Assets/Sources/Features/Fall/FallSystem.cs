using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class FallSystem : ISetPool, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.GameBoardElement.OnEntityRemoved(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        var gameBoard = _pool.gameBoard;
        for(int column = 0; column < gameBoard.columns; column++) {
            for(int row = 1; row < gameBoard.rows; row++) {
                var movables = _pool.GetEntitiesWithPosition(column, row)
                                    .Where(e => e.isMovable)
                                    .ToArray();

                foreach(var e in movables) {
                    moveDown(e, column, row);
                }
            }
        }
    }

    void moveDown(Entity e, int column, int row) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_pool, column, row);
        if(nextRowPos != row) {
            e.ReplacePosition(column, nextRowPos);
        }
    }
}
