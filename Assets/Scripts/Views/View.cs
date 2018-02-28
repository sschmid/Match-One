using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener {

    public virtual void Link(IEntity entity, IContext context) {
        gameObject.Link(entity, context);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        e.AddDestroyedListener(this);

        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, IntVector2 value) {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity) {
        destroy();
    }

    protected void destroy() {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
