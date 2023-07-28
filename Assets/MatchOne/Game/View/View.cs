using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace MatchOne
{
    public class View : MonoBehaviour, IView, IMatchOneGamePositionAddedListener, IMatchOneGameDestroyedAddedListener
    {
        protected Game.Entity _linkedEntity;

        public virtual void Link(Entity entity)
        {
            gameObject.Link(entity);
            _linkedEntity = (Game.Entity)entity;
            _linkedEntity.AddPositionAddedListener(this);
            _linkedEntity.AddDestroyedAddedListener(this);

            var pos = _linkedEntity.GetPosition().Value;
            transform.localPosition = new Vector3(pos.x, pos.y);
        }

        public virtual void OnPositionAdded(Game.Entity entity, Vector2Int value)
        {
            transform.localPosition = new Vector3(value.x, value.y);
        }

        public virtual void OnDestroyedAdded(Game.Entity entity)
        {
            OnDestroy();
        }

        protected virtual void OnDestroy()
        {
            gameObject.Unlink();
            Destroy(gameObject);
        }
    }
}
