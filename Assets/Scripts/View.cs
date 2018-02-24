using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener {

    protected GameEntity _linkedEntity;

    public virtual void Show() {
        onShown();
    }

    public virtual void Hide() {
        onHidden();
    }

    public virtual void Link(IEntity entity, IContext context) {
        gameObject.Link(entity, context);
        _linkedEntity = (GameEntity)entity;
        _linkedEntity.AddPositionListener(this);

        var pos = _linkedEntity.position.value;
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

    public virtual void OnPosition(GameEntity entity, IntVector2 value) {
        transform.localPosition = new Vector3(value.x, value.y);
    }
}
