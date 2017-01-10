using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class RemoveViewSystem : ReactiveSystem {

    public RemoveViewSystem(Contexts contexts) : base(contexts.core) {
        contexts.core.GetGroup(CoreMatcher.View).OnEntityRemoved += onEntityRemoved;
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.Asset, GroupEvent.Removed);
    }

    protected override bool Filter(Entity entity) {
        return entity.hasView;
    }

    protected override void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            e.RemoveView();
        }
    }

    void onEntityRemoved(Group group, Entity entity, int index, IComponent component) {
        var viewComponent = (ViewComponent)component;
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
