using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static MatchOne.BoardLogic;
using static MatchOne.MatchOneGameBoardMatcher;
using static MatchOne.MatchOneGameDestroyedMatcher;

namespace MatchOne
{
    public sealed class FillSystem : ReactiveSystem<Game.Entity>
    {
        readonly GameContext _gameContext;

        public FillSystem(GameContext gameContext) : base(gameContext)
        {
            _gameContext = gameContext;
        }

        protected override ICollector<Game.Entity> GetTrigger(IContext<Game.Entity> context) => context.CreateCollector(
            Destroyed.Added(),
            Board.Added());

        protected override bool Filter(Game.Entity entity) => true;

        protected override void Execute(List<Game.Entity> entities)
        {
            var board = _gameContext.GetBoard().Size;
            for (var x = 0; x < board.x; x++)
            {
                var position = new Vector2Int(x, board.y);
                var nextRowPos = GetNextEmptyRow(_gameContext, position);
                while (nextRowPos != board.y)
                {
                    _gameContext.CreateRandomPiece(x, nextRowPos);
                    nextRowPos = GetNextEmptyRow(_gameContext, position);
                }
            }
        }
    }
}
