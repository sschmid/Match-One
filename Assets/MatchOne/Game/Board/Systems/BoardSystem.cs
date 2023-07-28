using System.Collections.Generic;
using Entitas;
using MatchOne.Game;
using static MatchOne.MatchOneGameBoardMatcher;
using static MatchOne.MatchOneGamePieceMatcher;
using static MatchOne.MatchOneGamePositionMatcher;

namespace MatchOne
{
    public sealed class BoardSystem : ReactiveSystem<Game.Entity>, IInitializeSystem
    {
        readonly GameContext _gameContext;
        readonly ConfigContext _configContext;
        readonly IGroup<Game.Entity> _pieces;

        public BoardSystem(GameContext gameContext, ConfigContext configContext) : base(gameContext)
        {
            _gameContext = gameContext;
            _configContext = configContext;
            _pieces = gameContext.GetGroup(Matcher.AllOf(Piece, Position));
        }

        public void Initialize()
        {
            var config = _configContext.GetGameConfig().Value;
            var entity = _gameContext.CreateEntity();
            entity.AddBoard(config.BoardSize);

            for (var y = 0; y < config.BoardSize.y; y++)
            for (var x = 0; x < config.BoardSize.x; x++)
                if (Rand.Game.Bool(config.BlockerProbability))
                    _gameContext.CreateBlocker(x, y);
                else
                    _gameContext.CreateRandomPiece(x, y);
        }

        protected override ICollector<Game.Entity> GetTrigger(IContext<Game.Entity> context)
            => context.CreateCollector(Board);

        protected override bool Filter(Game.Entity entity)
            => entity.HasBoard();

        protected override void Execute(List<Game.Entity> entities)
        {
            var board = _gameContext.GetBoard().Size;
            foreach (var entity in _pieces)
                if (entity.GetPosition().Value.x >= board.x || entity.GetPosition().Value.y >= board.y)
                    entity.AddDestroyed();
        }
    }
}
