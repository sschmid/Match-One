using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem {

    readonly Transform _viewContainer = new GameObject("Views").transform;
    readonly Context _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _context = contexts.game;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasAsset;
    }

    protected override void Execute(List<Entity> entities) {
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

                if(e.hasPosition) {
                    var pos = e.position;
                    gameObject.transform.position = new Vector3(pos.x, pos.y + 1, 0f);
                }
            }
        }
    }
}
