using Entitas;
using UnityEngine;
using DG.Tweening;

public class RemoveViewSystem : IReactiveSystem, ISetPool {
    public IMatcher trigger { get { return Matcher.Resource; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityRemoved; } }

    public void SetPool(Pool pool) {
        pool.GetGroup(Matcher.View).OnEntityWillBeRemoved += onEntityWillBeRemoved;
    }

    void onEntityWillBeRemoved(Group group, Entity entity) {
        var gameObject = entity.view.gameObject;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.material.DOColor(color, 0.2f);
        gameObject.transform
            .DOScale(Vector3.one * 1.5f, 0.2f)
            .OnComplete(() => Object.Destroy(gameObject));
    }

    public void Execute(Entity[] entities) {

        UnityEngine.Debug.Log("RemoveViewSystem");

        foreach (var e in entities) {
            if (e.hasView) {
                e.RemoveView();
            }
        }
    }
}
