﻿using System.Collections.Generic;
using Entitas;
using static GameMatcher;

public sealed class BoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Contexts _contexts;
    readonly IGroup<GameEntity> _pieces;

    public BoardSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _pieces = contexts.game.GetGroup(AllOf(Piece, Position));
    }

    public void Initialize()
    {
        var config = _contexts.config.gameConfig.value;
        var entity = _contexts.game.CreateEntity();
        entity.AddBoard(config.BoardSize);

        for (var y = 0; y < config.BoardSize.y; y++)
        for (var x = 0; x < config.BoardSize.x; x++)
            if (Rand.game.Bool(config.BlockerProbability))
                _contexts.game.CreateBlocker(x, y);
            else
                _contexts.game.CreateRandomPiece(x, y);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(Board);

    protected override bool Filter(GameEntity entity) => entity.hasBoard;

    protected override void Execute(List<GameEntity> entities)
    {
        var board = _contexts.game.board.Size;
        foreach (var e in _pieces)
            if (e.position.Value.x >= board.x || e.position.Value.y >= board.y)
                e.isDestroyed = true;
    }
}
