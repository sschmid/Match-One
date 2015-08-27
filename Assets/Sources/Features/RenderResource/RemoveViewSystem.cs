using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool, IEnsureComponents {
    public TriggerOnEvent trigger { get { return Matcher.Resource.OnEntityRemoved(); } }

    public IMatcher ensureComponents { get { return Matcher.View; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(Matcher.View).OnEntityRemoved += onEntityRemoved;
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
            .OnComplete(() => Object.Destroy(gameObject));
    }

    public void Execute(List<Entity> entities) {

        Debug.Log("RemoveViewSystem");

        foreach (var e in entities) {
            e.RemoveView();
        }
    }
}
