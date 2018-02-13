using System.Collections.Generic;
using Entitas;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {

    public ViewService viewService = ViewService.singleton;

    readonly Contexts _contexts;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            var view = viewService.Instantiate(e.asset.value);
            e.AddView(view);
            view.Link(e, _contexts.game);
        }
    }
}
