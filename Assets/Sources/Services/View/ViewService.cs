using UnityEngine;

public class ViewService : IAssetListener {

    public static ViewService singleton = new ViewService();

    Contexts _contexts;
    Transform _parent;

    public void Initialize(Contexts contexts, Transform parent) {
        _contexts = contexts;
        _parent = parent;
        contexts.game.CreateEntity().AddAssetListener(this);
    }

    public void OnAsset(GameEntity entity, string value) {
        var prefab = Resources.Load<GameObject>(value);
        var view = Object.Instantiate(prefab, _parent).GetComponent<IView>();
        view.Link(entity, _contexts.game);
    }
}
