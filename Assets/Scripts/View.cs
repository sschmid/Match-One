using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener {

    public virtual void Show() {
        onShown();
    }

    public virtual void Hide() {
        onHidden();
    }

    public virtual void Link(IEntity entity, IContext context) {
        gameObject.Link(entity, context);
        var e = (GameEntity)entity;
        e.AddPositionListener(this);
        var pos = e.position.value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void Unlink() {
        gameObject.Unlink();
    }

    protected virtual void onShown() {
    }

    protected virtual void onHidden() {
        Destroy(gameObject);
    }

    public virtual void OnPosition(IntVector2 value) {
        transform.localPosition = new Vector3(value.x, value.y);
    }
}
