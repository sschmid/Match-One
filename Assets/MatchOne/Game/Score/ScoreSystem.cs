using System.Collections.Generic;
using Entitas;
using static MatchOne.MatchOneGameDestroyedMatcher;

namespace MatchOne
{
    public sealed class ScoreSystem : ReactiveSystem<Game.Entity>, IInitializeSystem
    {
        readonly GameContext _gameContext;
        readonly GameStateContext _gameStateContext;

        public ScoreSystem(GameContext gameContext, GameStateContext gameStateContext) : base(gameContext)
        {
            _gameContext = gameContext;
            _gameStateContext = gameStateContext;
        }

        public void Initialize()
        {
            _gameStateContext.SetScore(0);
        }

        protected override ICollector<Game.Entity> GetTrigger(IContext<Game.Entity> context)
            => context.CreateCollector(Destroyed);

        protected override bool Filter(Game.Entity entity)
            => entity.HasDestroyed() && entity.HasPiece();

        protected override void Execute(List<Game.Entity> entities)
        {
            _gameStateContext.ReplaceScore(_gameStateContext.GetScore().Value + entities.Count);
        }
    }
}
