using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameBoardSystem : ISetPool, IInitializeSystem, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.GameBoard.OnEntityAdded(); } }

    Pool _pool;
    Group _gameBoardElements;

    public void SetPool(Pool pool) {
        _pool = pool;
        _gameBoardElements = _pool.GetGroup(Matcher.AllOf(CoreMatcher.GameBoardElement, CoreMatcher.Position));
    }

    public void Initialize() {
        var gameBoard = _pool.SetGameBoard(8, 9).gameBoard;
        for(int row = 0; row < gameBoard.rows; row++) {
            for(int column = 0; column < gameBoard.columns; column++) {
                if(Random.value > 0.91f) {
                    _pool.CreateBlocker(column, row);
                } else {
                    _pool.CreateRandomPiece(column, row);
                }
            }
        }
    }

    public void Execute(List<Entity> entities) {
        var gameBoard = entities.SingleEntity().gameBoard;
        foreach(var e in _gameBoardElements.GetEntities()) {
            if(e.position.x >= gameBoard.columns || e.position.y >= gameBoard.rows) {
                e.isDestroy = true;
            }
        }
    }
}
