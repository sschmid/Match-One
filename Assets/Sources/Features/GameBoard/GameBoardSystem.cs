using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameBoardSystem : ReactiveSystem, IInitializeSystem {

    readonly Context _context;
    readonly Group _gameBoardElements;

    public GameBoardSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _gameBoardElements = _context.GetGroup(Matcher.AllOf(GameMatcher.GameBoardElement, GameMatcher.Position));
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.GameBoard);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasGameBoard;
    }

    public void Initialize() {
        var gameBoard = _context.SetGameBoard(8, 9).gameBoard;
        for(int row = 0; row < gameBoard.rows; row++) {
            for(int column = 0; column < gameBoard.columns; column++) {
                if(Random.value > 0.91f) {
                    _context.CreateBlocker(column, row);
                } else {
                    _context.CreateRandomPiece(column, row);
                }
            }
        }
    }

    protected override void Execute(List<Entity> entities) {
        var gameBoard = entities.SingleEntity().gameBoard;
        foreach(var e in _gameBoardElements.GetEntities()) {
            if(e.position.x >= gameBoard.columns || e.position.y >= gameBoard.rows) {
                e.isDestroy = true;
            }
        }
    }
}
