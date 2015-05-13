using Entitas;

namespace Entitas {
    public partial class Entity {
        public ViewComponent view { get { return (ViewComponent)GetComponent(GameComponentIds.View); } }

        public bool hasView { get { return HasComponent(GameComponentIds.View); } }

        public void AddView(ViewComponent component) {
            AddComponent(GameComponentIds.View, component);
        }

        public void AddView(UnityEngine.GameObject newGameObject) {
            var component = new ViewComponent();
            component.gameObject = newGameObject;
            AddView(component);
        }

        public void ReplaceView(UnityEngine.GameObject newGameObject) {
            ViewComponent component;
            if (hasView) {
                WillRemoveComponent(GameComponentIds.View);
                component = view;
            } else {
                component = new ViewComponent();
            }
            component.gameObject = newGameObject;
            ReplaceComponent(GameComponentIds.View, component);
        }

        public void RemoveView() {
            RemoveComponent(GameComponentIds.View);
        }
    }
}

    public partial class GameMatcher {
        static AllOfMatcher _matcherView;

        public static AllOfMatcher View {
            get {
                if (_matcherView == null) {
                    _matcherView = new GameMatcher(GameComponentIds.View);
                }

                return _matcherView;
            }
        }
    }
