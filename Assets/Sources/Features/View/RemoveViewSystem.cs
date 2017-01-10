using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class RemoveViewSystem : ReactiveSystem {

    public RemoveViewSystem(Contexts contexts) : base(contexts.game) {
    }

    protected override Collector GetTrigger(Context context) {
        return new Collector(
            new [] {
                context.GetGroup(GameMatcher.Asset),
                context.GetGroup(GameMatcher.Destroy)
            },
            new [] {
                GroupEvent.Removed,
                GroupEvent.Added
            }
        );
    }

    protected override bool Filter(Entity entity) {
        return entity.hasView;
    }

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            destroyView(e.view);
            e.RemoveView();
        }
    }

    void destroyView(ViewComponent viewComponent) {
        var gameObject = viewComponent.gameObject;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.material.DOColor(color, 0.2f);
        gameObject.transform
                  .DOScale(Vector3.one * 1.5f, 0.2f)
                  .OnComplete(() => {
                        gameObject.Unlink();
			            Object.Destroy(gameObject);
                    });
    }
}
