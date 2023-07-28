using System.Collections.Generic;
using Entitas;

namespace MatchOne
{
    public sealed class ProcessInputSystem : ReactiveSystem<Input.Entity>
    {
        readonly GameContext _gameContext;
        readonly InputContext _inputContext;

        public ProcessInputSystem(GameContext gameContext, InputContext inputContext) : base(inputContext)
        {
            _gameContext = gameContext;
            _inputContext = inputContext;
        }

        protected override ICollector<Input.Entity> GetTrigger(IContext<Input.Entity> context)
            => context.CreateCollector(MatchOneInputInputMatcher.Input);

        protected override bool Filter(Input.Entity entity)
            => entity.HasInput();

        protected override void Execute(List<Input.Entity> entities)
        {
            var entity = _gameContext.GetPieceWithPosition(_inputContext.GetInput().Value);
            if (entity != null && entity.HasInteractive())
                entity.AddDestroyed();
        }
    }
}
