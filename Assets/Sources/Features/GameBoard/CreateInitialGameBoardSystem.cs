using Entitas;
using UnityEngine;

public class CreateInitialGameBoardSystem : IStartSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Start() {
        var gameBoard = _pool.gameBoard;
        for (int row = 0; row < gameBoard.rows; row++) {
            for (int column = 0; column < gameBoard.columns; column++) {
                if (Random.value > 0.8f) {
                    _pool.CreateBlocker(column, row);
                } else {
                    _pool.CreateRandomPiece(column, row);
                }
            }
        }
    }
}

