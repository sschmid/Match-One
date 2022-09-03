using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener
{
    protected GameEntity _linkedEntity;

    public virtual void Link(IEntity entity)
    {
        gameObject.Link(entity);
        _linkedEntity = (GameEntity)entity;
        _linkedEntity.AddPositionListener(this);
        _linkedEntity.AddDestroyedListener(this);

        var pos = _linkedEntity.position.Value;
        transform.localPosition = new Vector3(pos.x, pos.y);
    }

    public virtual void OnPosition(GameEntity entity, Vector2Int value)
    {
        transform.localPosition = new Vector3(value.x, value.y);
    }

    public virtual void OnDestroyed(GameEntity entity) => OnDestroy();

    protected virtual void OnDestroy()
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
