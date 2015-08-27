using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FillSystem : IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.GameBoardElement.OnEntityRemoved(); } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("Fill");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        for (int column = 0; column < gameBoard.columns; column++) {
            var nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            while (nextRowPos != gameBoard.rows) {
                _pool.CreateRandomPiece(column, nextRowPos);
                nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            }
        }
    }
}

