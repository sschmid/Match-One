using System.Collections.Generic;
using Entitas;

public class FillSystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return Matcher.AllOf(Matcher.GameBoardElement, Matcher.Destroy); } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {

        UnityEngine.Debug.Log("Fill");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        for (int column = 0; column < gameBoard.columns; column++) {
            var nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            while (nextRowPos != gameBoard.rows) {
                var e = _pool.CreateRandomPiece(column, nextRowPos);
                nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
            }
        }
    }
}

