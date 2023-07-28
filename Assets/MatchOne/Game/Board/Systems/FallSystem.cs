using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static MatchOne.BoardLogic;
using static MatchOne.MatchOneGameDestroyedMatcher;

namespace MatchOne
{
    public sealed class FallSystem : ReactiveSystem<Game.Entity>
    {
        readonly GameContext _gameContext;

        public FallSystem(GameContext gameContext) : base(gameContext)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<Game.Entity> GetTrigger(IContext<Game.Entity> context)
            => context.CreateCollector(Destroyed);

        protected override bool Filter(Game.Entity entity)
            => entity.HasDestroyed() && entity.HasPiece();

        protected override void Execute(List<Game.Entity> entities)
        {
            var board = _gameContext.GetBoard().Size;
            for (var x = 0; x < board.x; x++)
            {
                for (var y = 1; y < board.y; y++)
                {
                    var position = new Vector2Int(x, y);
                    var entity = _gameContext.GetPieceWithPosition(position);
                    if (entity != null && entity.HasMovable())
                        MoveDown(entity, position);
                }
            }
        }

        void MoveDown(Game.Entity e, Vector2Int position)
        {
            var nextRowPos = GetNextEmptyRow(_gameContext, position);
            if (nextRowPos != position.y)
                e.ReplacePosition(new Vector2Int(position.x, nextRowPos));
        }
    }
}
