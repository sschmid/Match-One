using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class GameBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem {

    readonly GameContext _context;
    readonly IGroup<GameEntity> _gameBoardElements;

    public GameBoardSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
        _gameBoardElements = _context.GetGroup(GameMatcher.AllOf(GameMatcher.GameBoardElement, GameMatcher.Position));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoard);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasGameBoard;
    }

    public void Initialize() {
        var gameBoard = _context.CreateGameBoard().gameBoard;
        for (int row = 0; row < gameBoard.rows; row++) {
            for (int column = 0; column < gameBoard.columns; column++) {
                if (Random.value > 0.91f) {
                    _context.CreateBlocker(column, row);
                } else {
                    _context.CreateRandomPiece(column, row);
                }
            }
        }
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = entities.SingleEntity().gameBoard;
        foreach (var e in _gameBoardElements.GetEntities()) {
            if (e.position.value.x >= gameBoard.columns || e.position.value.y >= gameBoard.rows) {
                e.isDestroyed = true;
            }
        }
    }
}
