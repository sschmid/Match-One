using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.Resource.OnEntityAdded(); } }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(List<Entity> entities) {

        Debug.Log("Add View");

        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(res);
            } catch (Exception) {
                Debug.Log("Cannot instantiate " + res);
            }

            if (gameObject != null) {
                gameObject.transform.SetParent(_viewContainer, false);
                e.AddView(gameObject);

                if (e.hasPosition) {
                    var pos = e.position;
                    gameObject.transform.position = new Vector3(pos.x, pos.y + 1, 0f);
                }
            }
        }
    }
}