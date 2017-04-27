using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {

    readonly Transform _viewContainer = new GameObject("Views").transform;
    readonly GameContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {
            var asset = Resources.Load<GameObject>(e.asset.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(asset);
            } catch(Exception) {
                Debug.Log("Cannot instantiate " + e.asset.name);
            }

            if (gameObject != null) {
                gameObject.transform.SetParent(_viewContainer, false);
                e.AddView(gameObject);
                gameObject.Link(e, _context);
            }
        }
    }
}
