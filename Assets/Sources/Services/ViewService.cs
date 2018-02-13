using System;
using UnityEngine;

public class ViewService {

    public static ViewService singleton = new ViewService();

    Transform _viewContainer;

    public void Initialize(Transform viewContainer) {
        _viewContainer = viewContainer;
    }

    public IView Instantiate(string assetName) {
        var resource = Resources.Load<GameObject>(assetName);

        try {
            var gameObject = UnityEngine.Object.Instantiate(resource);
            gameObject.transform.SetParent(_viewContainer, false);
            return gameObject.GetComponent<IView>();
        } catch (Exception) {
            Debug.Log("Cannot instantiate " + assetName);
        }

        return null;
    }
}
