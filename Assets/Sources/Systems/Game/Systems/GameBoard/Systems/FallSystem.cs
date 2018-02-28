using System.Collections.Generic;
using System.Linq;
using Entitas;

public sealed class FallSystem : ReactiveSystem<GameEntity> {

    public GameBoardService gameBoardService = GameBoardService.singleton;

    readonly Contexts _contexts;

    public FallSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.GameBoardElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return !entity.isGameBoardElement;
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = _contexts.game.gameBoard;
        for (int column = 0; column < gameBoard.columns; column++) {
            for (int row = 1; row < gameBoard.rows; row++) {
                var position = new IntVector2(column, row);
                var movables = _contexts.game.GetEntitiesWithPosition(position)
                    .Where(e => e.isMovable)
                    .ToArray();

                foreach (var e in movables) {
                    moveDown(e, position);
                }
            }
        }
    }

    void moveDown(GameEntity e, IntVector2 position) {
        var nextRowPos = gameBoardService.GetNextEmptyRow(position);
        if (nextRowPos != position.y) {
            e.ReplacePosition(new IntVector2(position.x, nextRowPos));
        }
    }
}
