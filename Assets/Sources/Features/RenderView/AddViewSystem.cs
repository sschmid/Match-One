using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ISetPool, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.Asset.OnEntityAdded(); } }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var res = Resources.Load<GameObject>(e.asset.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(res);
            } catch(Exception) {
                Debug.Log("Cannot instantiate " + res);
            }

            if(gameObject != null) {
                gameObject.transform.SetParent(_viewContainer, false);
                e.AddView(gameObject);
                gameObject.Link(e, _pool);

                if(e.hasPosition) {
                    var pos = e.position;
                    gameObject.transform.position = new Vector3(pos.x, pos.y + 1, 0f);
                }
            }
        }
    }
}
