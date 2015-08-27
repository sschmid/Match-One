using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FallSystem : IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.GameBoardElement.OnEntityRemoved(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("Fall");

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
            e.ReplacePosition(column, nextRowPos);
        }
    }
}

