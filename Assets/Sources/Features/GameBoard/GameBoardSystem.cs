using Entitas;
using UnityEngine;

public class GameBoardSystem : IStartSystem, IReactiveSystem, ISetPool {
    Pool _pool;
    Group _gameBoardElements;

    public IMatcher trigger { get { return Matcher.GameBoard; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    public void SetPool(Pool pool) {
        _pool = pool;
        _gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
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

    public void Execute(Entity[] entities) {

        Debug.Log("Update GameBoard");

        var gameBoard = entities.SingleEntity().gameBoard;
        foreach (var e in _gameBoardElements.GetEntities()) {
            if (e.position.x >= gameBoard.columns || e.position.y >= gameBoard.rows) {
                e.isDestroy = true;
            }
        }
    }
}

