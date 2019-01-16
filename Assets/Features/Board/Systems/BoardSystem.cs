using System.Collections.Generic;
using Entitas;

public sealed class BoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Contexts _contexts;
    readonly IGroup<GameEntity> _pieces;

    public BoardSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _pieces = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Piece, GameMatcher.Position));
    }

    public void Initialize()
    {
        var entity = _contexts.game.CreateEntity();
        var boardSize = _contexts.config.gameConfig.value.boardSize;
        var blockerProbability = _contexts.config.gameConfig.value.blockerProbability;
        entity.AddBoard(boardSize);

        for (int y = 0; y < boardSize.y; y++)
        {
            for (int x = 0; x < boardSize.x; x++)
            {
                if (Rand.game.Bool(blockerProbability))
                {
                    _contexts.game.CreateBlocker(x, y);
                }
                else
                {
                    _contexts.game.CreateRandomPiece(x, y);
                }
            }
        }
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Board);

    protected override bool Filter(GameEntity entity) => entity.hasBoard;

    protected override void Execute(List<GameEntity> entities)
    {
        var board = entities.SingleEntity().board.value;
        foreach (var e in _pieces)
        {
            if (e.position.value.x >= board.x || e.position.value.y >= board.y)
            {
                e.isDestroyed = true;
            }
        }
    }
}
