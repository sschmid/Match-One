using UnityEngine;
using Entitas;
using System;

public class EntityLink : MonoBehaviour {

    public Entity entity { get { return _entity; } }
    public Pool pool { get { return _pool; } }

    Entity _entity;
    Pool _pool;

    public void Link(Entity entity, Pool pool) {
        if(_entity != null) {
            throw new Exception("EntityLink is already linked to " + _entity + "!");
        }

        _entity = entity;
        _pool = pool;
        _entity.Retain(this);
    }

    public void Unlink() {
        if(_entity == null) {
            throw new Exception("EntityLink is already unlinked!");
        }

        _entity.Release(this);
        _entity = null;
        _pool = null;
    }
}

public static class EntityLinkExtension {

    public static EntityLink GetEntityLink(this GameObject gameObject) {
        return gameObject.GetComponent<EntityLink>(); ;
    }

    public static EntityLink Link(this GameObject gameObject, Entity entity, Pool pool) {
        var link = gameObject.GetEntityLink();
        if(link == null) {
            link = gameObject.AddComponent<EntityLink>();
        }

        link.Link(entity, pool);
        return link;
    }

    public static void Unlink(this GameObject gameObject) {
        gameObject.GetEntityLink().Unlink();
    }
}
