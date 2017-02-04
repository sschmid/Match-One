using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity> {

    readonly Transform _viewContainer = new GameObject("Views").transform;
    readonly GameContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach(var e in entities) {
            var res = Resources.Load<GameObject>(e.asset.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(res);
            } catch(Exception) {
                Debug.Log("Cannot instantiate " + res);
            }

            if(gameObject != null) {
                gameObject.transform.SetParent(_viewContainer, false);
                e.AddView(gameObject);
                gameObject.Link(e, _context);
            }
        }
    }
}
