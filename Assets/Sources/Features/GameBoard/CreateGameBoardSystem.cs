using Entitas;
using UnityEngine;

public class CreateGameBoardSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {

        Debug.Log("Create GameBoard");

        var gameBoard = _pool.SetGameBoard(8, 9).gameBoard;
        for (int row = 0; row < gameBoard.rows; row++) {
            for (int column = 0; column < gameBoard.columns; column++) {
                if (Random.value > 0.91f) {
                    _pool.CreateBlocker(column, row);
                } else {
                    _pool.CreateRandomPiece(column, row);
                }
            }
        }
    }
}

