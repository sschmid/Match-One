using System.Collections.Generic;
using Entitas;

public class FallSystem : IReactiveSystem, ISetPool {

    Pool _pool;

    public IMatcher trigger { get { return Matcher.AllOf(Matcher.GameBoardElement); } }

    public GroupEventType eventType { get { return  GroupEventType.OnEntityRemoved; } }

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        UnityEngine.Debug.Log("Fall");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        for (int column = 0; column < gameBoard.columns; column++) {
            for (int row = 1; row < gameBoard.rows; row++) {
                var e = grid[column, row];
                if (e != null && e.isMovable) {
                    moveDown(e, column, row, grid);
                }
            }
        }
    }

    void moveDown(Entity e, int column, int row, Entity[,] grid) {
        var nextRowPos = grid.GetNextEmptyRow(column, row);
        if (nextRowPos != row) {
            grid[column, nextRowPos] = e;
            grid[column, row] = null;
            e.ReplacePosition(column, nextRowPos);
        }
    }
}

