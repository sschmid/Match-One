using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static MatchOne.MatchOneGameAssetMatcher;

namespace MatchOne
{
    public sealed class AddViewSystem : ReactiveSystem<Game.Entity>
    {
        readonly Transform _parent;

        public AddViewSystem(GameContext gameContext) : base(gameContext)
        {
            _parent = new GameObject("Views").transform;
        }

        protected override ICollector<Game.Entity> GetTrigger(IContext<Game.Entity> context)
            => context.CreateCollector(Asset);

        protected override bool Filter(Game.Entity entity)
            => entity.HasAsset() && !entity.HasView();

        protected override void Execute(List<Game.Entity> entities)
        {
            foreach (var entity in entities)
                entity.AddView(InstantiateView(entity));
        }

        IView InstantiateView(Game.Entity entity)
        {
            var prefab = Resources.Load<GameObject>(entity.GetAsset().Value);
            var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
            view.Link(entity);
            return view;
        }
    }
}
