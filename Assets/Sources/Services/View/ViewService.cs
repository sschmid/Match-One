using UnityEngine;

public class ViewService : IAnyAssetListener {

    public static ViewService singleton = new ViewService();

    Transform _parent;

    public void Initialize(Contexts contexts, Transform parent) {
        _parent = parent;
        contexts.game.CreateEntity().AddAnyAssetListener(this);
    }

    public void OnAnyAsset(GameEntity entity, string value) {
        var prefab = Resources.Load<GameObject>(value);
        var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
        view.Link(entity);
    }
}
