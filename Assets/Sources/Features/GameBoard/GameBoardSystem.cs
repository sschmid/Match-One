using System.Collections.Generic;
using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine;

public class GameBoardSystem : IInitializeSystem, IReactiveSystem, ISetPool {
    public TriggerOnEvent trigger { get { return Matcher.GameBoard.OnEntityAdded(); } }

    Blueprints _blueprints;
    Pool _pool;
    Group _gameBoardElements;

    public GameBoardSystem(Blueprints blueprints) {
        _blueprints = blueprints;
    }

    public void SetPool(Pool pool) {
        _pool = pool;
        _gameBoardElements = _pool.GetGroup(Matcher.AllOf(Matcher.GameBoardElement, Matcher.Position));
    }

    public void Initialize() {

        Debug.Log("Create GameBoard");

        var gameBoard = _pool.SetGameBoard(9, 9).gameBoard;
        for (int row = 0; row < gameBoard.rows; row++) {
            for (int column = 0; column < gameBoard.columns; column++) {
                if (Random.value > 0.91f) {
                    _blueprints.ApplyBlocker(_pool.CreateEntity(), column, row);
                } else {
                    _blueprints.ApplyPiece(_pool.CreateEntity(), column, row);
                }
            }
        }
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("Update GameBoard");

        var gameBoard = entities.SingleEntity().gameBoard;
        foreach (var e in _gameBoardElements.GetEntities()) {
            if (e.position.x >= gameBoard.columns || e.position.y >= gameBoard.rows) {
                e.isDestroy = true;
            }
        }
    }
}

