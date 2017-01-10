using System.Collections.Generic;
using Entitas;
using System.Linq;

public sealed class FallSystem : ReactiveSystem {

    readonly Context _contexts;

    public FallSystem(Contexts contexts) : base(contexts.core) {
        _contexts = contexts.core;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.GameBoardElement, GroupEvent.Removed);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        var gameBoard = _contexts.gameBoard;
        for(int column = 0; column < gameBoard.columns; column++) {
            for(int row = 1; row < gameBoard.rows; row++) {
                var movables = _contexts.GetEntitiesWithPosition(column, row)
                                    .Where(e => e.isMovable)
                                    .ToArray();

                foreach(var e in movables) {
                    moveDown(e, column, row);
                }
            }
        }
    }

    void moveDown(Entity e, int column, int row) {
        var nextRowPos = GameBoardLogic.GetNextEmptyRow(_contexts, column, row);
        if(nextRowPos != row) {
            e.ReplacePosition(column, nextRowPos);
        }
    }
}
