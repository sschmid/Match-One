using System.Collections.Generic;
using Entitas;

public sealed class FillSystem : ReactiveSystem<GameEntity> {

    public EntityService entityService = EntityService.singleton;
    public GameBoardService gameBoardService = GameBoardService.singleton;

    readonly Contexts _contexts;

    public FillSystem(Contexts contexts) : base(contexts.game) {
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
            var position = new IntVector2(column, gameBoard.rows);
            var nextRowPos = gameBoardService.GetNextEmptyRow(position);
            while (nextRowPos != gameBoard.rows) {
                entityService.CreateRandomPiece(column, nextRowPos);
                nextRowPos = gameBoardService.GetNextEmptyRow(position);
            }
        }
    }
}
